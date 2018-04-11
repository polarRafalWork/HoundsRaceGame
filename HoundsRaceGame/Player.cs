using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoundsRaceGame
{
    public class Player
    {
        // fields

        private string name;
        private Bet myBet;
        private int cash;
        private int id;

        private RadioButton myRadioButton;
        private Label myLabel;
        private bool betDone = false;


        // constructors

        public Player(string name, RadioButton myRadiobutton, Label myLabel, int id)
        {
            this.cash = 100;
            this.name = name;
            this.myRadioButton = myRadiobutton;
            this.myLabel = myLabel;
            this.id = id;
        }


        // setters and getters

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }

        public void SetCash(int cash)
        {
            this.cash = cash;
        }
        public int GetCash()
        {
            return this.cash;
        }

        public void SetRadioButton(RadioButton myRadioButton)
        {
            this.myRadioButton = myRadioButton;
        }
        public RadioButton GetRadioButton()
        {
            return myRadioButton;
        }
        public void SetLabel(Label myLabel)
        {
            this.myLabel = myLabel;
        }

        public Label GetLabel()
        {
            return myLabel;
        }

        public void SetBetDone (bool betDone)
        {
            this.betDone = betDone;
        }
        public bool GetBetDone()
        {
            return betDone;
        }

        public int GetId()
        {
            return id;
        }

        // methods




        public void UpdateLabels()
        {
            // ustaw moje pole tekstowe na opis zakladu a napis obok pola wyboru tak, aby pokazywał ilość pieniedzy
            myRadioButton.Text = name + " ma " + cash;
            if (betDone)
            {
                myLabel.Text = name + " stawia " + myBet.GetAmount() + " na charta numer " + myBet.GetDog();
            }
            else
            {
                myLabel.Text = name + " nie zawarł zakładu";
            }
            
        }

        public void ClearBet()
        {
            // wyczyść mój zakład aby był równy zero
            myBet = null;
            betDone = false;
        }

        public bool PlaceBet(int amount, int dogToWin)
        {
            // Ustal nowy zakład i przechowaj go w polu myBet
            myBet = new Bet(amount, dogToWin, this);

            // Zwróć true jeżeli facet ma wystarczającą ilość pieniędzy
            if (cash > amount)
            {
                betDone = true;
                return true;
            }
            else
            {
                betDone = false;
                return false;
            }
        }

        public void Collect (int winner)
        {
            // poproś o wypłatę zakładu i zaktualizuj etykiety
            if (myBet == null)
            {
                // gracz nie obstawił zakładu
            }
            else
            {
                cash += myBet.PayOut(winner);
            }
            
            
        }

    }
}
