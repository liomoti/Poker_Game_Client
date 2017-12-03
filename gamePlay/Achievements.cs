using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Project
{
 
    public partial class frmAchivment : Form
    {
        public string line;
        public string pathWinLose = Path.Combine(Environment.CurrentDirectory, "WinLoseHistory.txt");
        public string pathStrongestHand = Path.Combine(Environment.CurrentDirectory, "strongestHand.txt");

        public frmAchivment()
        {
            InitializeComponent();
        }
        //the func get string that represents win or lose
        //the func write it to the text file
        public void saveWinLose(string result)
        {
            FileStream fileWinLoseHistory = new FileStream(pathWinLose, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            StreamReader SR = new StreamReader(fileWinLoseHistory);
            string strToWrite="";
            if(result=="Win")
            {
                while ((line = SR.ReadLine()) != null)
                {
                    string[] spline = line.Split('-');
                    if(spline[0]=="Lose")
                        strToWrite="Lose-"+spline[1]+Environment.NewLine;                    
                    else
                    {
                        int numToWrite = Int32.Parse(spline[1])+1;                        
                        strToWrite += "Win-" + numToWrite;
                    }
                }
            }
            else if (result=="Lose")
            {
                while ((line = SR.ReadLine()) != null)
                {
                    string[] spline = line.Split('-');
                    if (spline[0] == "Lose")
                    {
                        int numToWrite = Int32.Parse(spline[1]) + 1;
                        strToWrite = "Lose-" + numToWrite + Environment.NewLine;
                    }
                    else                    
                        strToWrite += "Win-" + spline[1];

                }
            }
            SR.Close();
            StreamWriter SW = new StreamWriter(pathWinLose);
            SW.WriteLine(strToWrite);
            SW.Close();
        }
        //the func get the best hand of the player win with her
        //the func compare the hand with the hand in the history and write the strongest to the history file
        public void saveHand(string hand)
        {
            //hand format: Rank-card1-card2-card3-card4-card5-card6-card7
            //example of hand: 03-Nine diamond-King spade-Four club-King club-Two club-Seven heart-King heart
            //we pass the text file, if our hand is better we change, else all stay the same
            string handToWrite = "";
            string[] newHand = hand.Split('-');
            StreamReader fileHistoryHands = new StreamReader(pathStrongestHand);
            while ((line = fileHistoryHands.ReadLine()) != null)
            {
                string[] spline = line.Split('-');
                if(Int32.Parse(spline[0])<= Int32.Parse(newHand[0]))
                    handToWrite = hand;
                else
                    handToWrite = line;
            }
            fileHistoryHands.Close();

            //no we need to write the string "handToWrite" to the file
            StreamWriter fileNewHistoryHands = new StreamWriter(pathStrongestHand);
            fileNewHistoryHands.WriteLine(handToWrite);
            fileNewHistoryHands.Close();
        }
        private void frmAchivment_Load(object sender, EventArgs e)
        {
            int j = 0; //for WinLose label
            //show 
            string[] lineFromFile = {  };
            lbl_winLose.Text = "The Win/Lose statistics of this computer until " + "\n" + DateTime.Now.ToString() + " is:" + "\n\n";
            tb_strongHand.Text = "The Storngest Hand of this computer until " + "\n" + DateTime.Now.ToString() + " is:" + "\n\n";
            //reading     
            // Read the file strongestHand and display it line by line.
            StreamReader fileHistoryHands = new StreamReader(pathStrongestHand); 
            while ((line = fileHistoryHands.ReadLine()) != null)
            {
                lineFromFile = line.Split('-');
                //lbl_winLose.Text += line;
            }
            fileHistoryHands.Close();
            tb_strongHand.Text += lineFromFile[8]+"\n\n";
            for (int i = 1; i < 8; i++)
            {
                if (lineFromFile[i].Substring(0, 3) == "Ace")   //------>>>ace
                    lineFromFile[i] = string.Concat("01", lineFromFile[i]);
                if (lineFromFile[i].Substring(0, 3) == "Two")   //------>>>two
                    lineFromFile[i] = string.Concat("02", lineFromFile[i]);
                if (lineFromFile[i].Substring(0, 5) == "Three")  //------>>>three
                    lineFromFile[i] = string.Concat("03", lineFromFile[i]);
                if (lineFromFile[i].Substring(0, 4) == "Four")   //------>>>four
                    lineFromFile[i] = string.Concat("04", lineFromFile[i]);
                if (lineFromFile[i].Substring(0, 4) == "Five")    //------>>>five
                    lineFromFile[i] = string.Concat("05", lineFromFile[i]);
                if (lineFromFile[i].Substring(0, 3) == "Six")  //------>>>six
                    lineFromFile[i] = string.Concat("06", lineFromFile[i]);
                if (lineFromFile[i].Substring(0, 5) == "Seven")    //------>>>seven
                    lineFromFile[i] = string.Concat("07", lineFromFile[i]);
                if (lineFromFile[i].Substring(0, 5) == "Eight")    //------>>>eight
                    lineFromFile[i] = string.Concat("08", lineFromFile[i]);
                if (lineFromFile[i].Substring(0, 4) == "Nine")    //------>>>nine
                    lineFromFile[i] = string.Concat("09", lineFromFile[i]);
                if (lineFromFile[i].Substring(0, 3) == "Ten")     //------>>>ten
                    lineFromFile[i] = string.Concat("10", lineFromFile[i]);
                if (lineFromFile[i].Substring(0, 4) == "Jack")     //------>>>jack
                    lineFromFile[i] = string.Concat("11", lineFromFile[i]);
                if (lineFromFile[i].Substring(0, 5) == "Queen")    //------>>>queen
                    lineFromFile[i] = string.Concat("12", lineFromFile[i]);
                if (lineFromFile[i].Substring(0, 4) == "King")    //------>>>king
                    lineFromFile[i] = string.Concat("13", lineFromFile[i]);
            }


            for (int i = 0; i < 8; i++)
            {
                if (i == 6)
                    tb_strongHand.Text += "\n\n            ";
                string checkSuite = lineFromFile[i].Substring(lineFromFile[i].Length-1, 1);
                switch (checkSuite)
                {
                    case "t":
                        if(Int32.Parse(lineFromFile[i].Substring(0, 2))<11 && Int32.Parse(lineFromFile[i].Substring(0, 2))!=1)
                            tb_strongHand.Text += " "+ Int32.Parse(lineFromFile[i].Substring(0,2))+"♥";
                        else if(Int32.Parse(lineFromFile[i].Substring(0, 2))==1)
                            tb_strongHand.Text += "  A♥";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 11)
                            tb_strongHand.Text += "  J♥";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 12)
                            tb_strongHand.Text += "  Q♥";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 13)
                            tb_strongHand.Text += "  K♥";
                        break;
                    case "b":
                        if (Int32.Parse(lineFromFile[i].Substring(0, 2)) < 11 && Int32.Parse(lineFromFile[i].Substring(0, 2)) != 1)
                            tb_strongHand.Text += "  " + Int32.Parse(lineFromFile[i].Substring(0, 2)) + "♣";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 1)
                            tb_strongHand.Text += "  A♣";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 11)
                            tb_strongHand.Text += "  J♣";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 12)
                            tb_strongHand.Text += "  Q♣";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 13)
                            tb_strongHand.Text += "  K♣";
                        break;
                    case "d":
                        if (Int32.Parse(lineFromFile[i].Substring(0, 2)) < 11 && Int32.Parse(lineFromFile[i].Substring(0, 2)) != 1)
                            tb_strongHand.Text += "  " + Int32.Parse(lineFromFile[i].Substring(0, 2)) + "♦";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 1)
                            tb_strongHand.Text += "  A♦";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 11)
                            tb_strongHand.Text += "  J♦";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 12)
                            tb_strongHand.Text += "  Q♦";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 13)
                            tb_strongHand.Text += "  K♦";                        
                        break;
                    case "e":
                        if (Int32.Parse(lineFromFile[i].Substring(0, 2)) < 11 && Int32.Parse(lineFromFile[i].Substring(0, 2)) != 1)
                            tb_strongHand.Text += "  " + Int32.Parse(lineFromFile[i].Substring(0, 2)) + "♠";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 1)
                            tb_strongHand.Text += "  A♠";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 11)
                            tb_strongHand.Text += "  J♠";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 12)
                            tb_strongHand.Text += "  Q♠";
                        else if (Int32.Parse(lineFromFile[i].Substring(0, 2)) == 13)
                            tb_strongHand.Text += "  K♠";
                        break;
                }
            }

            /*
             * 10=RoyalStraightFlush
             * 9=straightFlush
             * 8=fourOfAKind
             * 7=fullHouse
             * 6=Flush
             * 5=Straight
             * 4=threeOfAKind
             * 3=twoPairs
             * 2=Pair
             * 1= there is no hand!
             */
            int winLoseSum=0;
            string[] spline = { "0", "0" };
            StreamReader sRHand = new StreamReader(pathWinLose);            
            while ((line = sRHand.ReadLine()) != null)
            {
                spline = line.Split('-');
                winLoseSum+=Int32.Parse(spline[1]);                
                if (j == 0)
                {
                    lbl_winLose.Text += spline[0] + "  " + spline[1] + Environment.NewLine;
                    j++;
                }
                else
                {
                    lbl_winLose.Text += spline[0] + "    " + spline[1] + Environment.NewLine;
                }
            }
            sRHand.Close();
            float num=0;
            if (winLoseSum!=0)
            {
                num = (Int32.Parse(spline[1]) * 100) / winLoseSum;
                lbl_winLose.Text +="              "+ num.ToString() + "%";
            }
            else
                lbl_winLose.Text += "              0%";
        }

        private void frmAchivment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnResetS_Click(object sender, EventArgs e)
        {
            //reset strongestHand.text file
            StreamWriter defaultHand = new StreamWriter(pathStrongestHand);
            defaultHand.WriteLine("0-Ace heart-Ace heart-Ace heart-Ace heart-Ace heart-Ace heart-Ace heart-There is no hand");
            defaultHand.Close();
            //reset WinLoseHistory.text file
            StreamWriter defaultWinLose = new StreamWriter(pathWinLose);
            defaultWinLose.WriteLine("Lose-0"+Environment.NewLine+"Win-0");
            defaultWinLose.Close();
            frmAchivment_Load(sender,e);
        }

        private void frmAchivment_FormClosing(object sender, FormClosingEventArgs e)
        {
            (this.Owner as frmStart).btnAchivments.Enabled = true;
        }
    }
}
