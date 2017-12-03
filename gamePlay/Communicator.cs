using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace Project
{
    
    public partial class frmCommunicator : Form
    {
        public string[] clientMessage;
        public bool connectionFlag = false;
        public bool thredIsLive = false;
        public byte[] inStream = new byte[10025];
        public frmAchivment achiv;
        public Socket sck;
        public Thread waitForOppT;
        public Player userName;
        public System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        public NetworkStream serverStream;
        public NetworkStream serverStream2;

        public frmCommunicator(Player userName, frmAchivment achiv)
        {
            InitializeComponent();
            this.userName = userName;
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            this.achiv = achiv;
            lblMyIp.Text = getLocalIP();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            if (!connectionFlag)
            {
                try
                {
                    clientSocket.Connect(tbOppIp.Text, 8001);
                    connectionFlag = !connectionFlag;
                    lblStatusConnectionText.ForeColor = Color.Green;
                    lblStatusConnectionText.Text = "Connected";
                    
                }
                catch (SocketException se)
                {
                    lblStatusConnectionText.ForeColor = Color.Red;
                    lblStatusConnectionText.Text = "Server did not found";
                    btnConnect.Enabled = true;
                }

            }
            if (connectionFlag)
            {
                try
                {
                    NetworkStream serverStream = clientSocket.GetStream();
                    this.serverStream2 = serverStream; //to save connection log
                    byte[] outStream = System.Text.Encoding.ASCII.GetBytes("name-" + userName.name.ToString() +"-$"); //preparing the data
                    serverStream.Write(outStream, 0, outStream.Length); //sending data to server
                    serverStream.Flush();
                    lblStatusConnectionText.ForeColor = Color.Blue;
                    lblStatusConnectionText.Text = "Looking for opponnet";
                    waitForOppT = new Thread(() => serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize));
                    thredIsLive = true;
                    waitForOppT.Start();
                    timerWaitForRdy.Start();


                }
                catch (Exception se2)
                {
                    lblStatusConnectionText.ForeColor = Color.Red;
                    lblStatusConnectionText.Text = "Error in server connection";
                    btnConnect.Enabled = true;
                }
            }
        }

        private string getLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            string username = userName.name.ToString();
            frmGamePlay playForm = new frmGamePlay(clientMessage[1].ToString(), serverStream,clientSocket,username,achiv);
            playForm.Owner = this;
            playForm.Show();
            this.Hide();
        }


        private void Communicator_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thredIsLive==true) //if the thread is created 
                waitForOppT.Abort(); //kill the thread
            (this.Owner as frmStart).btnConnect.Enabled = true;
            (this.Owner as frmStart).Show();
            
        }


        private void tbOppIp_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != Delete;
        }

        private void tbMyIp_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != Delete;
        }

        private void timerWaitForRdy_Tick(object sender, EventArgs e)
        {
            if(inStream!=null) //checking every second if the server send us back the Opponent name
            {              
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);            
                clientMessage = returndata.Split('-'); //cut the message to "READY" and "name"
                if (clientMessage[0].ToString() == "READY") //
                {
                    btnStartGame.Enabled = true;// enable the button start game
                    lblStatusConnectionText.ForeColor = Color.Green;
                    lblStatusConnectionText.Text = "Connected!"+"\n"+"Press Start Game!";
                    timerWaitForRdy.Stop();
                }
            }

        }

        private void frmCommunicator_Load(object sender, EventArgs e)
        {
            (this.Owner as frmStart).Hide();
        }
    }
}
