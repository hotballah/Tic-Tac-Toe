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

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        
        short turn = 0;
        short finish = 1;
        int move;
        int moved = 0;
        bool[] player1 = new bool[9];
        bool[] player2 = new bool[9];
        PictureBox[] pic = new PictureBox[9];
        string filePathP1Win = @"C:\Users\mabdi\Desktop\ICS\TicTacToe Database\P1 Win.txt";
        string filePathP2Win = @"C:\Users\mabdi\Desktop\ICS\TicTacToe Database\P2 Win.txt";
        string filePathDraw = @"C:\Users\mabdi\Desktop\ICS\TicTacToe Database\Draw.txt";


        string gameRecord = "";
        short gameCounter = 0;
        public Form1()
        {
            InitializeComponent();
            
            pic[0] = picBoxA1;
            pic[1] = picBoxB1;
            pic[2] = picBoxC1;
            pic[3] = picBoxA2;
            pic[4] = picBoxB2;
            pic[5] = picBoxC2;
            pic[6] = picBoxA3;
            pic[7] = picBoxB3;
            pic[8] = picBoxC3;

        }
        public void Reset()
        {
            gameCounter++;
            btnStart.Text = "" + gameCounter;
            

            
           

            btnStart.Update();
            gameRecord = "";
            turn = 0;
            finish = 1;
            for (short i = 0; i < player1.Length; i++)
            {
                player1[i] = false;
                player2[i] = false;
            }
            for (short i = 0; i < pic.Length; i++)
            {
                pic[i].Image = null;
                pic[i].Enabled = true;
            }
            moved++;


            

        }

        public void Drawer(PictureBox box, short num)
        {
            
            Image imgX = Image.FromFile(@"C:\Users\mabdi\Pictures\XO.png");
            Image imgO = Image.FromFile(@"C:\Users\mabdi\Pictures\XO (2).png");
            gameRecord +=  num + ";";
            switch (turn)
            {
                case 0:
                    turn++;
                    box.Image = imgX;
                    player1[num] = true;
                    break;
                case 1:
                    turn--;
                    box.Image = imgO;
                    player2[num] = true;
                    break;
            }
            box.Enabled = false;
            
            finish++;
            if ((player1[0] && player1[1] && player1[2]) || (player1[3] && player1[4] && player1[5]) || (player1[6] && player1[7] && player1[8]) || (player1[0] && player1[3] && player1[6]) || (player1[1] && player1[4] && player1[7]) || (player1[2] && player1[5] && player1[8]) || (player1[0] && player1[4] && player1[8]) || (player1[2] && player1[4] && player1[6]))
            {
                //MessageBox.Show("Player 1 Wins!!!", "Winner!!!");
                if (!CheckGames(gameRecord, filePathP1Win))
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePathP1Win, append: true))
                    {

                        file.WriteLine(gameRecord, Environment.NewLine);
                    }
                }
                gameRecord = gameRecord.Remove(gameRecord.Length - 6);
                if (CheckGames(gameRecord, filePathP2Win))
                {
                    string[] games = File.ReadAllLines(filePathP2Win);
                    games = games.Where(val => !val.Contains(gameRecord)).ToArray();
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePathP2Win))
                    {
                        for (int i = 0; i < games.Length; i++)
                        {
                            file.WriteLine(games[i]);
                        }
                    }

                }

                Reset();
            }
            else if ((player2[0] && player2[1] && player2[2]) || (player2[3] && player2[4] && player2[5]) || (player2[6] && player2[7] && player2[8]) || (player2[0] && player2[3] && player2[6]) || (player2[1] && player2[4] && player2[7]) || (player2[2] && player2[5] && player2[8]) || (player2[0] && player2[4] && player2[8]) || (player2[2] && player2[4] && player2[6]))
            {
                //MessageBox.Show("Player 2 Wins!!!", "Winner!!!");
                if (!CheckGames(gameRecord, filePathP2Win))
                {
                    
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePathP2Win, append: true))
                    {

                        file.WriteLine(gameRecord, Environment.NewLine);

                    }
                }
                gameRecord = gameRecord.Remove(gameRecord.Length - 6);
                if (CheckGames(gameRecord, filePathP1Win))
                {
                    string[] games = File.ReadAllLines(filePathP1Win);
                    games = games.Where(val => !val.Contains(gameRecord)).ToArray();
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePathP1Win))
                    {

                        file.Write("");

                    }
                    for (int i = 0; i < games.Length; i++)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePathP1Win, append: true))
                        {

                            file.WriteLine(games[i], Environment.NewLine);

                        }
                    }
                }

                Reset();
            } else if (finish == 10)
            {
                //MessageBox.Show("Tie Game!!!", "It's a Draw!!!");
                if (!CheckGames(gameRecord, filePathDraw))
                {
                    
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePathDraw, append: true))
                    {
                        file.WriteLine(gameRecord, Environment.NewLine);
                    }
                }
                gameRecord = gameRecord.Remove(gameRecord.Length - 6);
                if (CheckGames(gameRecord, filePathP2Win))
                {
                    string[] games = File.ReadAllLines(filePathP2Win);
                    games = games.Where(val => !val.Contains(gameRecord)).ToArray();
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePathP2Win))
                    {

                        file.Write("");

                    }
                    for (int i = 0; i < games.Length; i++)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePathP2Win, append: true))
                        {

                            file.WriteLine(games[i], Environment.NewLine);

                        }
                    }
                }
                if (CheckGames(gameRecord, filePathP1Win))
                {
                    string[] games = File.ReadAllLines(filePathP1Win);
                    games = games.Where(val => !val.Contains(gameRecord)).ToArray();
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePathP1Win))
                    {

                        file.Write("");

                    }
                    for (int i = 0; i < games.Length; i++)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePathP1Win, append: true))
                        {

                            file.WriteLine(games[i], Environment.NewLine);

                        }
                    }
                }
                Reset();
            }
            //if (moved <= 190)
            //{
            //    if (turn == 0)
            //    {
            //        Computer1();
            //    }
            //    else if (turn == 1)
            //    {
            //        Computer2();
            //    }
            //}

        }
        public bool CheckGames(string ThisGame, string file)
        {
            string[] games = File.ReadAllLines(file);
            foreach (string game in games)
            {
                if (game.Contains(ThisGame))
                {
                    return true;
                }
            }
            return false;
        }
        /* Commented out Computer 2 for debugging reasons. If you want it to play un comment everything, including the methods */
        //public void Computer2()
        //{
        //    string[] games = File.ReadAllLines(filePathP2Win); // FIle p2 for debugging reasons!! Go back to player 1 for automation
        //    for (int j = 0; j < games.Length; j++)
        //    {
        //        if (games[j].Contains(gameRecord))
        //        {
        //            for (int i = 0; i < gameRecord.Length; i += 2)
        //            {
        //                if (games[j][i] == gameRecord[i])
        //                {

        //                    move = short.Parse(games[j][i + 2].ToString());
        //                    if (pic[move].Enabled == true)
        //                    {
        //                        goto here;
        //                    }
        //                }

        //            }

        //        }
        //    }
        //    if (pic[move].Enabled == false)
        //    {
        //        int x = 0;

        //        while (pic[move].Enabled == false)
        //        {
        //            Random rnd = new Random();
        //            x = rnd.Next(0, 9);
        //            move = x;
        //        }
        //    }
        //    here:

        //    Drawer(pic[move], (short)move);
        //}
        public void Computer1()
        {

            string[] games = File.ReadAllLines(filePathP1Win); 
            for (int j = 0;j < games.Length; j++)
            {
                if (games[j].Contains(gameRecord))
                {
                    for (int i = 0; i < gameRecord.Length; i += 2)
                    {
                        if (games[j][i] == gameRecord[i])
                        {

                            move = short.Parse(games[j][i + 2].ToString());
                            if (pic[move].Enabled == true)
                            {
                                goto here;
                            }
                        }

                    }

                }
            }
            if (pic[move].Enabled == false)
            {
                int x = 0;

                while (pic[move].Enabled == false)
                {
                    Random rnd = new Random();
                    x = rnd.Next(0, 9);
                    move = x;
                }
            }
            here:

            Drawer(pic[move], (short)move);



        }
        private void picBoxC3_Click(object sender, EventArgs e)
        {
            move = 8;

            Drawer(pic[8], 8);

            Computer1();

        }

        private void picBoxB3_Click(object sender, EventArgs e)
        {
            move = 7;
            Drawer(pic[7], 7);
            Computer1();

        }

        private void picBoxA3_Click(object sender, EventArgs e)
        {
            move = 6;
            Drawer(pic[6], 6);
            Computer1();

        }

        private void picBoxC2_Click(object sender, EventArgs e)
        {
            move = 5;
            Drawer(pic[5], 5);
            Computer1();

        }

        private void picBoxB2_Click(object sender, EventArgs e)
        {
            move = 4;
            Drawer(pic[4], 4);
            Computer1();

        }

        private void picBoxA2_Click(object sender, EventArgs e)
        {
            move = 3;
            Drawer(pic[3], 3);
            Computer1();

        }

        

        private void picBoxC1_Click(object sender, EventArgs e)
        {
            move = 2;
            Drawer(pic[2], 2);
            Computer1();

        }

        private void picBoxB1_Click(object sender, EventArgs e)
        {
            move = 1;
            Drawer(pic[1], 1);
            Computer1();

        }

        private void picBoxA1_Click(object sender, EventArgs e)
        {
            move = 0;
            Drawer(pic[0], 0);
            Computer1();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
            Computer1();
            gameCounter = 0;
            moved = 0;
        }
    }
}
