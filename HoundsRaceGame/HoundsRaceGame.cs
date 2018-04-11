using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HoundsRaceGame
{
    public partial class HoundsRaceGame : Form
    {

        Player currentPlayer = null;
        Player[] players = new Player[3]; // tablica obiektów graczy
        GreyHound[] greyhouds = new GreyHound[4]; // tablica obiektów greyhound

        public HoundsRaceGame()
        {
            InitializeComponent();
            InitializeRaceGame();
      
        }


        // inicjalizacja gry

        public void InitializeRaceGame()
        {
            // Inicjalizuj psy wyścigowe

            PictureBox[] pictureBoxes = new PictureBox[4];
            pictureBoxes[0] = pictureBox_hound0;
            pictureBoxes[1] = pictureBox_hound1;
            pictureBoxes[2] = pictureBox_hound2;
            pictureBoxes[3] = pictureBox_hound3;

           

            for (int i = 0; i < greyhouds.Length; i++)
            {
                greyhouds[i] = new GreyHound(pictureBoxes[i], i);
            }


            Random random = new Random();
            int totalRaceTrackLength = pictureBox_raceTrack.Width + pictureBox_raceTrack.Location.X - pictureBox_hound0.Location.X - pictureBox_hound0.Width;


            foreach (GreyHound greyhound in greyhouds)
            {
                greyhound.SetRandom(random);
                greyhound.SetStartingPosition();
                greyhound.SetRacetrackLength(totalRaceTrackLength);
            }


            

            // Inicjalizuj graczy

            players[0] = new Player("Janek", radioB_janek, label_janek,0);
            players[1] = new Player("Bartek", radioB_bartek, label_bartek,1);
            players[2] = new Player("Arek", radioB_arek, label_arek,2);


        
            UpdateAllLabels(players);
        }

        
        public void UpdateAllLabels(Player[] players)
        {
            foreach(Player guy in players)
            {
                guy.UpdateLabels();
            }
        }

        // EVENTS

        private void button_bet_Click(object sender, EventArgs e)
        {
            currentPlayer.PlaceBet((int)numericUpDown_stake.Value, (int)numericUpDown_houndNum.Value);
            UpdateAllLabels(players);
        }

        private void radioB_janek_CheckedChanged(object sender, EventArgs e)
        {
            currentPlayer = players[0];
            label_currentBettor.Text = currentPlayer.GetName() + " stawia";
        }

        private void radioB_bartek_CheckedChanged(object sender, EventArgs e)
        {
            currentPlayer = players[1];
            label_currentBettor.Text = currentPlayer.GetName() + " stawia";
        }

        private void radioB_arek_CheckedChanged(object sender, EventArgs e)
        {
            currentPlayer = players[2];
            label_currentBettor.Text = currentPlayer.GetName() + " stawia";
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            // Rozpocznij wyścig
            //MessageBox.Show("Uwaga, start wyścigu!", "START");
            ButtonsOnOff();
            raceClock.Start();

        }

        private void numericUpDown_speed_ValueChanged(object sender, EventArgs e)
        {
            foreach (GreyHound greyhound in greyhouds)
            {
                int speed = (int)numericUpDown_speed.Value;
                greyhound.SetSpeed(speed);
            }
        }

        // Włącz/ wyłącz przyciski do edycji
        private void ButtonsOnOff()
        {
            if(button_bet.Enabled == true)
            {
                button_bet.Enabled = false;
                numericUpDown_houndNum.Enabled = false;
                numericUpDown_stake.Enabled = false;
                radioB_janek.Enabled = false;
                radioB_bartek.Enabled = false;
                radioB_arek.Enabled = false;
            }
            else
            {
                button_bet.Enabled = true;
                numericUpDown_houndNum.Enabled = true;
                numericUpDown_stake.Enabled = true;
                radioB_janek.Enabled = true;
                radioB_bartek.Enabled = true;
                radioB_arek.Enabled = true;
            }
            
        }

        // Przygotuj nową grę

        private void PrepareNewGame()
        {
            GreyHound.ResetWinnerDog();
            int a = GreyHound.WinnerDog();
            foreach (GreyHound greyhound in greyhouds)
            {
                greyhound.TakeStartingPosition();
            }
        }

        private void raceClock_Tick(object sender, EventArgs e)
        {


            foreach (GreyHound greyhound in greyhouds)
            {
                if (greyhound.Run())
                {
                    raceClock.Stop();
                    MessageBox.Show("Wygrał " + GreyHound.WinnerDog());

                    if (raceClock.Enabled == false)
                    {
                        // Zakończ wyścig - podsumuj

                        foreach (Player player in players)
                        {
                            player.Collect(GreyHound.WinnerDog());
                        }

                        // Przygotuj nową grę

                        PrepareNewGame();
                        ButtonsOnOff();
                        UpdateAllLabels(players);
                    }

                    return;
                }
            }
        }


    }
}
