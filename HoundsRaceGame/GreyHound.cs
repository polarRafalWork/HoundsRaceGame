using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoundsRaceGame
{
    public class GreyHound
    {
        // FIELDS

        private int startingPosition; // miejsce gdzie rozpoczyna się pictureBox
        private int racetrackLength; // jak dluga jest trasa
        private PictureBox myPictureBox = null; // moj obiekt picturebox
        private int location = 0; // moje polozenie na torze wyscigowym
        private Random myRandom; // instancja klasy Random
        private int speed = 1;
        private int id;
        private static int winnerDog = -1;

        // CONSTRUCTORS

        public GreyHound(PictureBox pictureBox, int id)
        {
            this.myPictureBox = pictureBox;
            this.id = id;
        }

        // GETTERS AND SETTERS

        public static int WinnerDog()
        {
            return winnerDog;
        }
        public static void ResetWinnerDog()
        {
            winnerDog = -1;
        }
        public void SetRandom(Random myRandom)
        {
            this.myRandom = myRandom;
        }

        public void SetRacetrackLength(int racetrackLength)
        {
            this.racetrackLength = racetrackLength;
        }

        public void SetPictureBox(PictureBox myPictureBox)
        {
            this.myPictureBox = myPictureBox;
        }
        public PictureBox GetPictureBox()
        {
            return myPictureBox;
        }
        public void SetStartingPosition ()
        {
            this.startingPosition = myPictureBox.Left;

        }
        public int GetStartingPosition()
        {
            return startingPosition;
        }

        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }

        // METHODS

        public bool Run()
        {
            int movement = myRandom.Next(1, 4);
            // przesun sie do przodu losowo o 1,2,3,4 punkty
            location += movement*speed;
            // zaktualizuj polozenie pucturebox na formularzu
            myPictureBox.Left += movement*speed;

            // zwroc true jezeli wygralem wyscig
            if (location>=racetrackLength && winnerDog==-1)
            {
                winnerDog = id + 1;
                return true;
                
            }
            else
            {
                return false;
            }

        }

        public void TakeStartingPosition()
        {
            myPictureBox.Left = startingPosition;
            location = 0;
        }


    }
}
