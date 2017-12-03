using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Project
{
    public partial class frmGamePlay : Form
    {
        private Table table = new Table();
        private int bet;
        public frmAchivment achiv;
        private int countRounds = 0;
        private string raise = "1";
        private string opponentBet;
        private string opponentBetValue;
        private string OpponentName;
        public string[] ClientMessage = { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", };
        public string checkButtonOff = Path.Combine(Environment.CurrentDirectory, "CheckbuttonOff");
        public string checkButtonOn = Path.Combine(Environment.CurrentDirectory, "CheckbuttonOn");
        public string raiseButtonOn = Path.Combine(Environment.CurrentDirectory, "raiseButtonOn");
        public string raiseButtonOff = Path.Combine(Environment.CurrentDirectory, "raiseButtonOff");
        public string callButtonOn = Path.Combine(Environment.CurrentDirectory, "callButtonOn");
        public string callButtonOff = Path.Combine(Environment.CurrentDirectory, "callButtonOff");
        public string okButton = Path.Combine(Environment.CurrentDirectory, "okButton");
        public string foldButton = Path.Combine(Environment.CurrentDirectory, "foldButton");
        public string foldButtonOff = Path.Combine(Environment.CurrentDirectory, "foldButtonOff");
        public NetworkStream serverStream;
        public TcpClient clientSocket;
        public Thread WaitForcards;
        public byte[] inStream = new byte[10025];
        public bool flagForThread = true;
        public bool ThredIsLive = false;
        public bool exitProgram = true;
        public bool userPlay = false;
        public bool closeGamePlay = false;
        private bool isServerShutDown = true;

        public frmGamePlay(string opponentName, NetworkStream serverStream, TcpClient clientSocket, string userName, frmAchivment achiv)
        {
            InitializeComponent();
            string[] newOpponentName = opponentName.Split('\0', '1');
            this.OpponentName = newOpponentName[0];
            this.serverStream = serverStream;
            this.clientSocket = clientSocket;
            tbPlayer.Text = userName;
            lbl_state.Text = "Press Start and wait for " + OpponentName.ToString();
            this.achiv = achiv;
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            string callButtonOn = Path.Combine(Environment.CurrentDirectory, "callButtonOff");
            countRounds++;
            tbPotTotalScore.Text = (Int32.Parse(tbPotTotalScore.Text) + Int32.Parse(opponentBetValue)).ToString();
            tbScore.Text = (Int32.Parse(tbScore.Text) - Int32.Parse(opponentBetValue)).ToString();
            sendStringtoServer("CALL-" + tbScore.Text); //sending to the server

            if (countRounds == 1)
            {
                timerFlop2.Start();
            }
            else if (countRounds == 2)
            {
                timerTurn3.Start();
            }
            else if (countRounds == 3)
            {
                timerRiver4.Start();
            }
            else if (countRounds == 4)
            {
                timerEndGame5.Start();
            }
            btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
            btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
            tbRaise.Visible = false;
            btnOk.Visible = false;
            tbBetUpdate.Visible = false;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
            btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
            btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
            btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
            btnStart.Hide();
            btnCall.Visible = true;
            btnCheck.Visible = true;
            btnFold.Visible = true;
            btnRaise.Visible = true;
            btnFold.Enabled = false;
            btnCheck.Enabled = false;
            btnRaise.Enabled = false;
            btnCall.Enabled = false;
            tbRaise.Visible = false;
            btnOk.Visible = false;
            tbBetUpdate.Visible = false;
            sendStringtoServer("start"); //sending to the server
            WaitForcards = new Thread(threadFunction);
            ThredIsLive = true;
            WaitForcards.Start();
            timerStartGame1.Start();
            //waiting for getting 2 cards from the server
            //calling to function that show the cards on the table
        }
        private void sendStringtoServer(string str)
        {
            serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(str + "$"); //preparing the data
            serverStream.Write(outStream, 0, outStream.Length); //sending data to server
            serverStream.Flush();
        }
        private void frmGamePlay_Load(object sender, EventArgs e)
        {
            tbOpponent.Text = OpponentName;
            frmStart.ActiveForm.Hide();
        }
        private void threadFunction()
        {

            while (exitProgram) //make the thread work
            {
                    if (flagForThread == true) //bool to puse the thread
                    {
                        try{
                        serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                        }
                        catch (Exception se)
                        {
                            if (isServerShutDown == true)
                            {
                                MessageBox.Show("Oops! \r\n The server has been shut down");
                            }
                            break;                           
                        }
                    }
            }
            closeGamePlay = true; 
            closeTimer.Start();
        }
        private void BtnCall_MouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void tbRaise_Scroll(object sender, EventArgs e)
        {
            tbRaise.Maximum = Math.Min(Int32.Parse(tbScore.Text), Int32.Parse(tbOppPot.Text)); //set the Max of the track Bar
            tbBetUpdate.Text = tbRaise.Value.ToString(); //show it     
            raise = tbBetUpdate.Text;
        }
        private void btnRaise_Click(object sender, EventArgs e)
        {
            tbRaise.Visible = true;
            btnOk.Visible = true;
            tbBetUpdate.Visible = true;
            tbRaise.Value = 1; //reset the track bar to Start Point
            tbBetUpdate.Text = "1"; //reset the label to Start Point
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
            countRounds++;
            tbPotTotalScore.Text = (Int32.Parse(tbPotTotalScore.Text) + tbRaise.Value).ToString();
            table.myLastBet = "RAISE";
            btnFold.Enabled = false;
            btnCheck.Enabled = false;
            btnRaise.Enabled = false;
            tbRaise.Visible = false;
            btnOk.Visible = false;
            tbBetUpdate.Visible = false;
            tbScore.Text = (Int32.Parse(tbScore.Text) - Int32.Parse(tbBetUpdate.Text)).ToString();
            if (countRounds == 1)
            {
                timerFlop2.Start();
            }
            else if (countRounds == 2)
            {
                timerTurn3.Start();
            }
            else if (countRounds == 3)
            {
                timerRiver4.Start();
            }
            else if (countRounds == 4)
            {
                timerEndGame5.Start();
            }
            sendStringtoServer("RAISE-" + tbBetUpdate.Text + "-" + tbScore.Text); //sending to the server                                                                         // sendStringtoServer("RAISE-" + raise.ToString() + "-" + tbScore.Text); //sending to the server
            lbl_state.Text = "you raised ..." + tbBetUpdate.Text;
        }
        private void btnFold_Click(object sender, EventArgs e)
        {
            btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
            countRounds = 0; ///set the counter of all the timers to be zero for the next round
            sendStringtoServer("FOLD$"); //sending to the server
            lbl_state.Text = "sending Fold...:(";
            userPlay = true; ///start timer 2!
            btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
            btnRaise.Enabled = true; //enabled raise button
            btnCheck.Enabled = true; //enabled check button
            btnFold.Enabled = true; //enabled fold button
            btnCall.Enabled = false;

            pbPlayerCard1.Image = Image.FromFile("_Back" + ".png");  //the back of the card
            pbPlayerCard2.Image = Image.FromFile("_Back" + ".png");
            pbTableCard1.Image = Image.FromFile("_Back" + ".png");
            pbTableCard2.Image = Image.FromFile("_Back" + ".png");
            pbTableCard3.Image = Image.FromFile("_Back" + ".png");
            pbTableCard4.Image = Image.FromFile("_Back" + ".png");
            pbTableCard5.Image = Image.FromFile("_Back" + ".png");
            tbOppPot.Text = (Int32.Parse(tbOppPot.Text) + Int32.Parse(tbPotTotalScore.Text)).ToString(); //update the opponnent pot
            tbRaise.Visible = false;
            btnOk.Visible = false;
            tbBetUpdate.Visible = false;
            tbPotTotalScore.Text = "0";
            btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
            btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
            timerStartGame1.Start();
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
            countRounds++;
            table.myLastBet = "CHECK";  //saving the last bet of this player
            sendStringtoServer("CHECK$"); //sending to the server
            lbl_state.Text = "sending Check...";
            if (countRounds == 1)
            {
                timerFlop2.Start();
            }
            else if (countRounds == 2)
            {
                timerTurn3.Start();
            }
            else if (countRounds == 3)
            {
                timerRiver4.Start();
            }
            else if (countRounds == 4)
            {
                timerEndGame5.Start();
            }
            btnCheck.Enabled = false;
            btnFold.Enabled = false;
            btnRaise.Enabled = false;
            btnCall.Enabled = false;
            tbRaise.Visible = false;
            btnOk.Visible = false;
            tbBetUpdate.Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (inStream != null) //checking every second if the server send us back the Opponent name
            {
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                ClientMessage = returndata.Split('-'); //cut the message to "READY" and "name"
                if (ClientMessage[0] == "ENDGAME")  //check if the game end
                {
                    isServerShutDown = false;
                    timerStartGame1.Stop();
                    lbl_state.Text = "The opponnet dont want to replay";
                    MessageBox.Show("The opponnet dont want to play again");
                    (this.Owner as frmCommunicator).Close();  // close Communicator form + this form

                }
                if (ClientMessage[0].ToString() == "START")
                {
                    if (ClientMessage[1].ToString() == "p1") //if you are player 1
                    {
                        //one second delay
                        var t = Task.Run(async delegate
                        {
                            await Task.Delay(1000);
                        });
                        t.Wait();
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                        btnFold.Enabled = true;
                        btnCheck.Enabled = true;
                        btnRaise.Enabled = true;
                        tbRaise.Visible = false;
                        btnOk.Visible = false;
                        tbBetUpdate.Visible = false;
                    }
                    else if (ClientMessage[1].ToString() == "p2") //if you are player 2
                    {
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
                        btnFold.Enabled = false;
                        btnCheck.Enabled = false;
                        btnRaise.Enabled = false;
                        tbRaise.Visible = false;
                        btnOk.Visible = false;
                        tbBetUpdate.Visible = false;
                    }
                }
                if (ClientMessage[0].ToString() == "CARDS") //
                {
                    table.playerCards[0] = ClientMessage[2];
                    table.playerCards[1] = ClientMessage[3];
                    pbPlayerCard1.Image = Image.FromFile(table.playerCards[0] + ".png");
                    pbPlayerCard2.Image = Image.FromFile(table.playerCards[1] + ".png");
                    //ClientMessage[4] saved for player turn
                    table.tableCards[0] = ClientMessage[5];
                    table.tableCards[1] = ClientMessage[6];
                    table.tableCards[2] = ClientMessage[7];
                    table.tableCards[3] = ClientMessage[8];
                    table.tableCards[4] = ClientMessage[9];
                    if (ClientMessage[4] == "1") //we player 1
                    {
                        lbl_state.Text = "Your turn";
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                        btnRaise.Enabled = true; //enabled raise button
                        btnCheck.Enabled = true; //enabled check button
                        btnFold.Enabled = true; //enabled fold button
                        btnCall.Enabled = false;
                        timerStartGame1.Stop();
                        // if player 1 or player 2 got Zero Score ==> Cannot rase
                        if (tbOppPot.Text == "0" || tbScore.Text == "0")
                        {
                            btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                            btnRaise.Enabled = false;
                        }
                    }
                    else if (ClientMessage[4] == "2") //we player 2
                    {
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
                        lbl_state.Text = OpponentName.Insert(OpponentName.Length, " Turn");
                        btnCall.Enabled = false;
                        btnRaise.Enabled = false;
                        btnCheck.Enabled = false;
                        btnFold.Enabled = false;
                        timerFlop2.Start();  //starting timer 2 only in player 2 
                        timerStartGame1.Stop();
                    }
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            serverStream.Flush();
            if (inStream != null) //checking every second if the server send us back the Opponent name
            {
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                ClientMessage = returndata.Split('-'); //cut the message to 
                                                       // lbl_state.Text = returndata;
                if (ClientMessage[0].ToString() == "CHECK") //
                {
                    btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                    btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                    btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: CHECK");
                    btnRaise.Enabled = false; //enabled raise button
                    btnCheck.Enabled = true; //enabled check button
                    btnFold.Enabled = true; //enabled fold button
                    ClientMessage[0] = "";
                    timerFlop2.Stop();
                }
                if (ClientMessage[0].ToString() == "CALL") //
                {
                    btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                    btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                    btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: call");
                    btnRaise.Enabled = true; //enabled raise button
                    btnCheck.Enabled = false; //enabled check button
                    btnFold.Enabled = true; //enabled fold button
                    btnCall.Enabled = false;
                    ClientMessage[0] = "";
                    timerFlop2.Stop();
                }
                if (ClientMessage[2].ToString() == "FLOP") //
                {
                    lbl_state.Text = "Flop!";
                    //show cards
                    pbTableCard1.Image = Image.FromFile(table.tableCards[0] + ".png");
                    pbTableCard2.Image = Image.FromFile(table.tableCards[1] + ".png");
                    pbTableCard3.Image = Image.FromFile(table.tableCards[2] + ".png");
                    if (ClientMessage[0] == "1")
                    {
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                        btnRaise.Enabled = true; //enabled raise button
                        btnCheck.Enabled = true; //enabled check button
                        btnFold.Enabled = true; //enabled fold button
                        btnCall.Enabled = false;
                        // if player 1 or player 2 got Zero Score ==>Cannot rase
                        if (tbOppPot.Text == "0" || tbScore.Text == "0")
                        {
                            btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                            btnRaise.Enabled = false;
                        }
                    }
                    else if (ClientMessage[0] == "2")
                    {

                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");

                        btnRaise.Enabled = false; //enabled raise button
                        btnCheck.Enabled = false; //enabled check button
                        btnFold.Enabled = false; //enabled fold button
                        btnCall.Enabled = false;
                        timerTurn3.Start();  //starting timer3 for player 2    
                    }
                    if (ClientMessage[0] == "1" && ClientMessage[1] == "CHECK")
                    {
                        timerTurn3.Start();
                    }

                    if (ClientMessage[0] == "1" && ClientMessage[1] == "CALL") //this orders only for player 1 if player 2 play with call button
                    {
                        tbOppPot.Text = ClientMessage[3];//update the opponnet pot score (it will updated only in player1)
                        tbPotTotalScore.Text = (Int32.Parse(tbPotTotalScore.Text) + Int32.Parse(ClientMessage[4])).ToString();
                        // if player 1 or player 2 got Zero Score ==>Cannot raise
                        if (tbOppPot.Text == "0" || tbScore.Text == "0")
                        {
                            btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                            btnRaise.Enabled = false;
                        }
                        timerTurn3.Start();  //starting timer3 for player 1
                    }
                    timerFlop2.Stop();
                }
                if (ClientMessage[0].ToString() == "FOLD") //
                {
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: FOLD" + " " + "You Win!!!");
                    tbScore.Text = (Int32.Parse(tbScore.Text) + Int32.Parse(tbPotTotalScore.Text)).ToString(); //set the new player pot
                    tbPotTotalScore.Text = "0";
                    //    Set all Cards to Be On Back Side
                    pbPlayerCard1.Image = Image.FromFile("_Back" + ".png");  //the back of the card
                    pbPlayerCard2.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard1.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard2.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard3.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard4.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard5.Image = Image.FromFile("_Back" + ".png");

                    if (ClientMessage[1] == "1")
                    {
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                        btnRaise.Enabled = true; //enabled raise button
                        btnCheck.Enabled = true; //enabled check button
                        btnFold.Enabled = true; //enabled fold button
                        btnCall.Enabled = false;
                    }
                    else if (ClientMessage[1] == "2")
                    {

                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
                        btnRaise.Enabled = false; //enabled raise button
                        btnCheck.Enabled = false; //enabled check button
                        btnFold.Enabled = false; //enabled fold button
                        btnCall.Enabled = false;
                    }
                    ClientMessage[0] = "";
                    countRounds = 0; //the game end  so timer counter set to zero
                    timerFlop2.Stop(); //end this timer
                    timerStartGame1.Start(); //for the next round
                }

                if (ClientMessage[0].ToString() == "RAISE") //
                {
                    btnCall.Image = System.Drawing.Image.FromFile("callButtonOn.jpg");
                    btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                    btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                    btnRaise.Enabled = false; //enabled raise button
                    btnCheck.Enabled = false; //enabled check button
                    btnFold.Enabled = true; //enabled fold button
                    btnCall.Enabled = true;
                    opponentBet = ClientMessage[0].ToString(); //global 
                    opponentBetValue = ClientMessage[2].ToString(); //global 
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: RAISE by:" + opponentBetValue);
                    tbPotTotalScore.Text = (Int32.Parse(tbPotTotalScore.Text) + Int32.Parse(opponentBetValue)).ToString(); //update the new pot
                    tbOppPot.Text = ClientMessage[3]; //oppnent pot update
                    timerFlop2.Stop();
                }
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            serverStream.Flush();
            if (inStream != null) //checking every second if the server send us back the Opponent name
            {
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                ClientMessage = returndata.Split('-'); //cut the message to 
                if (ClientMessage[0].ToString() == "CHECK") //
                {
                    btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                    btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                    btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: CHECK");
                    btnRaise.Enabled = false; //enabled raise button
                    btnCheck.Enabled = true; //enabled check button
                    btnFold.Enabled = true; //enabled fold button
                    ClientMessage[0] = "";
                    timerTurn3.Stop();
                }
                if (ClientMessage[0].ToString() == "CALL") //
                {
                    btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                    btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                    btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: call");
                    btnRaise.Enabled = true; //enabled raise button
                    btnCheck.Enabled = false; //enabled check button
                    btnFold.Enabled = true; //enabled fold button
                    btnCall.Enabled = false;
                    ClientMessage[0] = "";
                }
                if (ClientMessage[2].ToString() == "TURN") //
                {
                    lbl_state.Text = "Turn Cards!";
                    //show cards
                    pbTableCard4.Image = Image.FromFile(table.tableCards[3] + ".png");
                    if (ClientMessage[0] == "1")
                    {
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                        btnRaise.Enabled = true; //enabled raise button
                        btnCheck.Enabled = true; //enabled check button
                        btnFold.Enabled = true; //enabled fold button
                        btnCall.Enabled = false;
                        // if player 1 or player 2 got Zero Score ==>Cannot raise
                        if (tbOppPot.Text == "0" || tbScore.Text == "0")
                        {
                            btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                            btnRaise.Enabled = false;
                        }
                    }
                    else if (ClientMessage[0] == "2")
                    {
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
                        btnRaise.Enabled = false; //enabled raise button
                        btnCheck.Enabled = false; //enabled check button
                        btnFold.Enabled = false; //enabled fold button
                        btnCall.Enabled = false;
                        timerRiver4.Start();  //starting timer for player 2    
                    }
                    if (ClientMessage[0] == "1" && ClientMessage[1] == "CHECK")
                    {
                        timerRiver4.Start();
                    }

                    if (ClientMessage[0] == "1" && ClientMessage[1] == "CALL") //this orders only for player 1 if player 2 playe with call button
                    {
                        tbOppPot.Text = ClientMessage[3];//update the opponnet pot score (will update only in player1)
                        tbPotTotalScore.Text = (Int32.Parse(tbPotTotalScore.Text) + Int32.Parse(ClientMessage[4])).ToString();
                        // if player 1 or player 2 got Zero Score ==>Cannot raise
                        if (tbOppPot.Text == "0" || tbScore.Text == "0")
                        {
                            btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                            btnRaise.Enabled = false;
                        }
                        timerRiver4.Start();  //starting timer for player 1
                    }
                    timerTurn3.Stop();
                }
                if (ClientMessage[0].ToString() == "FOLD") //
                {
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: FOLD" + " " + "You Win!!!");
                    tbScore.Text = (Int32.Parse(tbScore.Text) + Int32.Parse(tbPotTotalScore.Text)).ToString(); //set the new player pot
                    tbPotTotalScore.Text = "0";
                    //         Set all Cards to Be On Back Side
                    pbPlayerCard1.Image = Image.FromFile("_Back" + ".png");  //the back of the card
                    pbPlayerCard2.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard1.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard2.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard3.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard4.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard5.Image = Image.FromFile("_Back" + ".png");
                    tbScore.Text = (Int32.Parse(tbScore.Text) + Int32.Parse(tbPotTotalScore.Text)).ToString();

                    if (ClientMessage[1] == "1")
                    {
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                        btnRaise.Enabled = true; //enabled raise button
                        btnCheck.Enabled = true; //enabled check button
                        btnFold.Enabled = true; //enabled fold button
                        btnCall.Enabled = false;
                    }
                    else if (ClientMessage[1] == "2")
                    {
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
                        btnRaise.Enabled = false; //enabled raise button
                        btnCheck.Enabled = false; //enabled check button
                        btnFold.Enabled = false; //enabled fold button
                        btnCall.Enabled = false;
                    }
                    ClientMessage[0] = "";
                    countRounds = 0; //the game end so timer counter set to zero
                    timerTurn3.Stop();
                    timerStartGame1.Start(); //for the next round
                }

                if (ClientMessage[0].ToString() == "RAISE") //
                {
                    btnCall.Image = System.Drawing.Image.FromFile("callButtonOn.jpg");
                    btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                    btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                    btnRaise.Enabled = false; //enabled raise button
                    btnCheck.Enabled = false; //enabled check button
                    btnFold.Enabled = true; //enabled fold button
                    btnCall.Enabled = true;
                    opponentBet = ClientMessage[0].ToString(); //global 
                    opponentBetValue = ClientMessage[2].ToString(); //global 
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: RAISE by:" + opponentBetValue);
                    tbPotTotalScore.Text = (Int32.Parse(tbPotTotalScore.Text) + Int32.Parse(opponentBetValue)).ToString(); //update the new pot
                    tbOppPot.Text = ClientMessage[3]; //oppnent pot update
                    timerTurn3.Stop();
                }
            }

        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            serverStream.Flush();
            if (inStream != null) //checking every second if the server send us back the Opponent name
            {
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                ClientMessage = returndata.Split('-'); //cut the message to 
                if (ClientMessage[0].ToString() == "CHECK") //
                {
                    btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                    btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                    btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: CHECK");
                    btnRaise.Enabled = false; //enabled raise button
                    btnCheck.Enabled = true; //enabled check button
                    btnFold.Enabled = true; //enabled fold button
                    ClientMessage[0] = "";
                    timerRiver4.Stop();
                }
                if (ClientMessage[0].ToString() == "CALL") //
                {
                    btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                    btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                    btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: call");
                    btnRaise.Enabled = true; //enabled raise button
                    btnCheck.Enabled = false; //enabled check button
                    btnFold.Enabled = true; //enabled fold button
                    btnCall.Enabled = false;
                    ClientMessage[0] = "";
                }
                if (ClientMessage[2].ToString() == "RIVER") //
                {
                    lbl_state.Text = "River Cards!";
                    //show cards
                    pbTableCard5.Image = Image.FromFile(table.tableCards[4] + ".png");
                    if (ClientMessage[0] == "1")
                    {
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                        btnRaise.Enabled = true; //enabled raise button
                        btnCheck.Enabled = true; //enabled check button
                        btnFold.Enabled = true; //enabled fold button
                        btnCall.Enabled = false;
                        // if player 1 or player 2 got Zero Score ==>Cannot raise
                        if (tbOppPot.Text == "0" || tbScore.Text == "0")
                        {
                            btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                            btnRaise.Enabled = false;
                        }
                    }
                    else if (ClientMessage[0] == "2")
                    {

                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
                        btnRaise.Enabled = false; //enabled raise button
                        btnCheck.Enabled = false; //enabled check button
                        btnFold.Enabled = false; //enabled fold button
                        btnCall.Enabled = false;
                        timerEndGame5.Start();  //starting timer for player 2    
                    }
                    if (ClientMessage[0] == "1" && ClientMessage[1] == "CHECK")
                    {
                        timerEndGame5.Start();
                    }

                    if (ClientMessage[0] == "1" && ClientMessage[1] == "CALL") //this orders only for player 1 if player 2 playe with call button
                    {
                        tbOppPot.Text = ClientMessage[3];//update the opponnet pot score (will update only in player1)
                        tbPotTotalScore.Text = (Int32.Parse(tbPotTotalScore.Text) + Int32.Parse(ClientMessage[4])).ToString();
                        // if player 1 or player 2 got Zero Score ==>Cannot raise
                        if (tbOppPot.Text == "0" || tbScore.Text == "0")
                        {
                            btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                            btnRaise.Enabled = false;
                        }
                        timerEndGame5.Start();  //starting timer for player 1
                    }
                    timerRiver4.Stop();
                }
                if (ClientMessage[0].ToString() == "FOLD") //
                {
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: FOLD" + " " + "You Win!!!");
                    tbScore.Text = (Int32.Parse(tbScore.Text) + Int32.Parse(tbPotTotalScore.Text)).ToString(); //set the new player pot
                    tbPotTotalScore.Text = "0";
                    //               Set all Cards to Be On Back Side
                    pbPlayerCard1.Image = Image.FromFile("_Back" + ".png");  //the back of the card
                    pbPlayerCard2.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard1.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard2.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard3.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard4.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard5.Image = Image.FromFile("_Back" + ".png");
                    tbScore.Text = (Int32.Parse(tbScore.Text) + Int32.Parse(tbPotTotalScore.Text)).ToString();

                    if (ClientMessage[1] == "1")
                    {
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                        btnRaise.Enabled = true; //enabled raise button
                        btnCheck.Enabled = true; //enabled check button
                        btnFold.Enabled = true; //enabled fold button
                        btnCall.Enabled = false;
                    }
                    else if (ClientMessage[1] == "2")
                    {
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
                        btnRaise.Enabled = false; //enabled raise button
                        btnCheck.Enabled = false; //enabled check button
                        btnFold.Enabled = false; //enabled fold button
                        btnCall.Enabled = false;
                    }
                    ClientMessage[0] = "";
                    countRounds = 0; //timer counter must set to zero!
                    timerRiver4.Stop();
                    timerStartGame1.Start(); //for the next round
                }

                if (ClientMessage[0].ToString() == "RAISE") //
                {
                    btnCall.Image = System.Drawing.Image.FromFile("callButtonOn.jpg");
                    btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                    btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                    btnRaise.Enabled = false; //enabled raise button
                    btnCheck.Enabled = false; //enabled check button
                    btnFold.Enabled = true; //enabled fold button
                    btnCall.Enabled = true;
                    opponentBet = ClientMessage[0].ToString(); //global 
                    opponentBetValue = ClientMessage[2].ToString(); //global 
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: RAISE by:" + opponentBetValue);
                    tbPotTotalScore.Text = (Int32.Parse(tbPotTotalScore.Text) + Int32.Parse(opponentBetValue)).ToString(); //update the new pot
                    tbOppPot.Text = ClientMessage[3]; //opponent pot update
                    timerRiver4.Stop();
                }
            }
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            serverStream.Flush();
            if (inStream != null) //checking every second if the server send us back the Opponent name
            {
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                ClientMessage = returndata.Split('-'); //cut the message to 
                if (ClientMessage[0].ToString() == "CHECK") //
                {
                    btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                    btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                    btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: CHECK");
                    btnRaise.Enabled = false; //enabled raise button
                    btnCheck.Enabled = true; //enabled check button
                    btnFold.Enabled = true; //enabled fold button
                    ClientMessage[0] = "";
                    timerEndGame5.Stop();
                }
                if (ClientMessage[0].ToString() == "CALL") //
                {
                    btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                    btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                    btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: call");
                    btnRaise.Enabled = true; //enabled raise button
                    btnCheck.Enabled = false; //enabled check button
                    btnFold.Enabled = true; //enabled fold button
                    btnCall.Enabled = false;
                    ClientMessage[0] = "";
                }

                if (ClientMessage[2].ToString() == "WINNER") // 
                {
                    lbl_hand.Text = "Winning hand is:\r\n" + ClientMessage[6].ToString(); //win hand rank
                    //Delay The Program
                    //show cards
                    if (ClientMessage[0] == "1" && ClientMessage[1] == "CALL") //this orders only for player 1 if player 2 playe with call button
                    {
                        tbPotTotalScore.Text = (Int32.Parse(tbPotTotalScore.Text) + Int32.Parse(ClientMessage[3])).ToString(); //ClientMessage[3] = call offer
                        tbOppPot.Text = (Int32.Parse(tbOppPot.Text) - Int32.Parse(ClientMessage[3])).ToString();
                        // if player 1 or player 2 got Zero Score ==>Cannot raise
                        if (tbOppPot.Text == "0" || tbScore.Text == "0")
                        {
                            btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                            btnRaise.Enabled = false;
                        }
                    }
                    pbOppCard1.Image = Image.FromFile(ClientMessage[8] + ".png");
                    pbOppCard2.Image = Image.FromFile(ClientMessage[9] + ".png");                
                    if (ClientMessage[0] == "1")
                    {
                        if (ClientMessage[4] == "1") // player 1 won
                        {
                            tbScore.Text = (Int32.Parse(tbScore.Text) + Int32.Parse(tbPotTotalScore.Text)).ToString();
                            tbPotTotalScore.Text = "0";
                            lbl_state.Text = "you won the round";
                            //call to func to write hand to file
                            string writeHandRank = ClientMessage[10];
                            string hand = writeHandRank + "-"+table.tableCards[0]+"-"+ table.tableCards[1] + "-" + table.tableCards[2] + "-" + table.tableCards[3]
                                + "-" +table.tableCards[4] + "-" + table.playerCards[0] + "-" + table.playerCards[1] + "-" + ClientMessage[6];
                            //example of hand = "03-Nine diamond-King spade-Four club-King club-Two club-Seven heart-King heart";
                            achiv.saveHand(hand);
                        }
                        else if (ClientMessage[4] == "2") // player 2 won
                        {
                            tbOppPot.Text = (Int32.Parse(tbOppPot.Text) + Int32.Parse(tbPotTotalScore.Text)).ToString();
                            tbPotTotalScore.Text = "0";
                            lbl_state.Text = "you lose the round";
                        }
                        else if (ClientMessage[4] == "DRAW") // DRAW
                        {
                            tbScore.Text = (Int32.Parse(tbScore.Text) + Int32.Parse(tbPotTotalScore.Text) / 2).ToString();
                            tbOppPot.Text = (Int32.Parse(tbOppPot.Text) + Int32.Parse(tbPotTotalScore.Text) / 2).ToString();
                            tbPotTotalScore.Text = "0";
                            lbl_state.Text = "DRAW";
                        }
                        // if player 1 or player 2 got Zero Score ==>Cannot rase
                        if (tbOppPot.Text == "0" || tbScore.Text == "0")
                        {
                            btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                            btnRaise.Enabled = false;
                        }
                        var t1 = Task.Run(async delegate
                        {
                            await Task.Delay(4000);
                            return 1;
                        });
                        t1.Wait();
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                        btnRaise.Enabled = true; //enabled raise button
                        btnCheck.Enabled = true; //enabled check button
                        btnFold.Enabled = true; //enabled fold button
                        btnCall.Enabled = false;
                    }
                    else if (ClientMessage[0] == "2")
                    {
                        if (ClientMessage[4] == "1") // player 1 won
                        {
                            tbOppPot.Text = (Int32.Parse(tbOppPot.Text) + Int32.Parse(tbPotTotalScore.Text)).ToString();
                            tbPotTotalScore.Text = "0";
                            lbl_state.Text = "you lose the round";
                        }
                        else if (ClientMessage[4] == "2") // player 2 won
                        {
                            tbScore.Text = (Int32.Parse(tbScore.Text) + Int32.Parse(tbPotTotalScore.Text)).ToString();
                            tbPotTotalScore.Text = "0";
                            lbl_state.Text = "you won the round";
                            //call to func to write hand to file
                            string writeHandRank = ClientMessage[10];
                            string hand = writeHandRank + "-" + table.tableCards[0] + "-" + table.tableCards[1] + "-" + table.tableCards[2] + "-" + table.tableCards[3]
                                + "-" + table.tableCards[4] + "-" + table.playerCards[0] + "-" + table.playerCards[1] + "-" + ClientMessage[6];
                            //example of hand = "03-Nine diamond-King spade-Four club-King club-Two club-Seven heart-King heart";
                            achiv.saveHand(hand);
                        }
                        else if (ClientMessage[4] == "DRAW") // DRAW
                        {
                            tbScore.Text = (Int32.Parse(tbScore.Text) + Int32.Parse(tbPotTotalScore.Text) / 2).ToString();
                            tbOppPot.Text = (Int32.Parse(tbOppPot.Text) + Int32.Parse(tbPotTotalScore.Text) / 2).ToString();
                            tbPotTotalScore.Text = "0";
                            lbl_state.Text = "DRAW";
                        }
                        var t2 = Task.Run(async delegate
                        {
                            await Task.Delay(4000);
                            // return 1;
                        });
                        t2.Wait();
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
                        btnRaise.Enabled = false; //enabled raise button
                        btnCheck.Enabled = false; //enabled check button
                        btnFold.Enabled = false; //enabled fold button
                        btnCall.Enabled = false;
                    }
                    lbl_hand.Text = "";
                    pbPlayerCard1.Image = Image.FromFile("_Back" + ".png");  //the back of the card
                    pbPlayerCard2.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard1.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard2.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard3.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard4.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard5.Image = Image.FromFile("_Back" + ".png");
                    pbOppCard1.Image = Image.FromFile("_Back" + ".png");
                    pbOppCard2.Image = Image.FromFile("_Back" + ".png");

                    //check if the game end --> if end go to the main form
                    if (ClientMessage[7] == "endGame")
                    {
                        lbl_state.Text = "The game end";
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
                        btnRaise.Enabled = false; //enabled raise button
                        btnCheck.Enabled = false; //enabled check button
                        btnFold.Enabled = false; //enabled fold button
                        btnCall.Enabled = false;
                        timerEndGame5.Stop();
                        DialogResult dialogResult;
                        if (tbScore.Text == "0" || tbOpponent.Text == "2000")
                        {
                            dialogResult = MessageBox.Show("You lose the game! \n Want to Start new game?", "Game end", MessageBoxButtons.YesNo); //check if the user want to play new game
                            achiv.saveWinLose("Lose");
                        }
                        else
                        {
                            dialogResult = MessageBox.Show("Congratulations, You Won the game! \n Want to Start new game?", "Game end", MessageBoxButtons.YesNo); //check if the user want to play new game
                            achiv.saveWinLose("Win");
                        }
                        if (dialogResult == DialogResult.Yes)
                        {
                            sendStringtoServer("NEWGAME$"); //sending to the server
                            tbOppPot.Text = "1000";
                            tbScore.Text = "1000";
                            if (ClientMessage[0] == "1")
                            {
                                btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                                btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
                                btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
                                btnRaise.Enabled = false; //enabled raise button
                                btnCheck.Enabled = false; //enabled check button
                                btnFold.Enabled = false; //enabled fold button
                                lbl_state.Text = "waiting for opponnet";
                                timerEndGame5.Stop();
                                countRounds = 0; //timer counter must set to zero!
                                timerStartGame1.Start(); //for the next round
                            }
                            else if (ClientMessage[0] == "2")
                            {
                                lbl_state.Text = "waiting for opponnet";
                                timerEndGame5.Stop();
                                countRounds = 0; //timer counter must set to zero!
                                timerStartGame1.Start(); //for the next round
                            }
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            isServerShutDown = false;
                            sendStringtoServer("ENDGAME$"); //sending to the server
                            (this.Owner as frmCommunicator).Close();  // close Communicator form + this form
                        }
                    }
                    else if (ClientMessage[7] != "endGame") // the players stil got money!
                    {
                        timerEndGame5.Stop();
                        countRounds = 0; //timer counter must set to zero!
                        timerStartGame1.Start(); //for the next round
                    }
                }
                if (ClientMessage[0].ToString() == "FOLD") //
                {
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: FOLD" + " " + "You Win!!!");
                    tbScore.Text = (Int32.Parse(tbScore.Text) + Int32.Parse(tbPotTotalScore.Text)).ToString(); //set the new player pot
                    tbPotTotalScore.Text = "0";
                    //           Set all Cards to Be On Back Side
                    pbPlayerCard1.Image = Image.FromFile("_Back" + ".png");  //the back of the card
                    pbPlayerCard2.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard1.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard2.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard3.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard4.Image = Image.FromFile("_Back" + ".png");
                    pbTableCard5.Image = Image.FromFile("_Back" + ".png");
                    tbScore.Text = (Int32.Parse(tbScore.Text) + Int32.Parse(tbPotTotalScore.Text)).ToString();
                    tbPotTotalScore.Text = "0";
                    if (ClientMessage[1] == "1")
                    {
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOn.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOn.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                        btnRaise.Enabled = true; //enabled raise button
                        btnCheck.Enabled = true; //enabled check button
                        btnFold.Enabled = true; //enabled fold button
                        btnCall.Enabled = false;
                    }
                    else if (ClientMessage[1] == "2")
                    {
                        btnCall.Image = System.Drawing.Image.FromFile("callButtonOff.jpg");
                        btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                        btnCheck.Image = System.Drawing.Image.FromFile("checkButtonOff.jpg");
                        btnFold.Image = System.Drawing.Image.FromFile("FoldButtonOff.jpg");
                        btnRaise.Enabled = false; //enabled raise button
                        btnCheck.Enabled = false; //enabled check button
                        btnFold.Enabled = false; //enabled fold button
                        btnCall.Enabled = false;
                    }
                    ClientMessage[0] = "";
                    countRounds = 0; //timer counter must set to zero!
                    timerEndGame5.Stop();
                    timerStartGame1.Start(); //for the next round
                }
                if (ClientMessage[0].ToString() == "RAISE") //
                {
                    btnCall.Image = System.Drawing.Image.FromFile("callButtonOn.jpg");
                    btnRaise.Image = System.Drawing.Image.FromFile("raiseButtonOff.jpg");
                    btnFold.Image = System.Drawing.Image.FromFile("FoldButton.jpg");
                    btnRaise.Enabled = false; //enabled raise button
                    btnCheck.Enabled = false; //enabled check button
                    btnFold.Enabled = true; //enabled fold button
                    btnCall.Enabled = true;
                    opponentBet = ClientMessage[0].ToString(); //global 
                    opponentBetValue = ClientMessage[2].ToString(); //global 
                    lbl_state.Text = OpponentName.Insert(OpponentName.Length, " says: RAISE by:" + opponentBetValue);
                    tbPotTotalScore.Text = (Int32.Parse(tbPotTotalScore.Text) + Int32.Parse(opponentBetValue)).ToString(); //update the new pot
                    tbOppPot.Text = ClientMessage[3]; //oppnent pot update
                    timerEndGame5.Stop();
                }
            }
        }
        private void closeTimer_Tick(object sender, EventArgs e)
        {
            if (closeGamePlay)
                (this.Owner as frmCommunicator).Close();
        }

        private void frmGamePlay_FormClosed(object sender, FormClosedEventArgs e)
        {
            exitProgram = false;
            if (ThredIsLive == true) //if the thread is created 
                WaitForcards.Abort(); //kill the thread
            (this.Owner as frmCommunicator).Show();
        }
    }
}