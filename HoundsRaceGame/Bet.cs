using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoundsRaceGame
{
    public class Bet
    {
        private int amount;
        private int dog;
        private Player bettor;

        public Bet(int amount, int dog, Player bettor)
        {
            this.amount = amount;
            this.dog = dog;
            this.bettor = bettor;
        }


        public int GetAmount()
        {
            return amount;
        }
        public int GetDog()
        {
            return dog;
        }

        public string GetDescription()
        {
            // zwraca string ktory określa, kto obstawił wyścig, jak dużo pieniędzy postawił i na którego psa
            // jeżeli ilość jest równa zero, zakład nie został zawarty - komunikat

            if (amount >= 5)
            {
                return bettor.GetName() + " obstawił " + amount + " na psa nr. " + dog;
            }
            else
            {
                return "Nie można obstawić za mniej niż 5zł";
            }

        }

        public int PayOut (int winner)
        {
            // parametrem jest zwycięzca wyścigu. Jeżeli pies wygrał, zwróć wartość postawioną. W przeciwnym razie zwróć wartość postawioną ze znakiem minus
            if (winner == dog)
            {
                return 2 * amount;
            }
            else
            {
                return -amount;
            }
        }
    }
}
