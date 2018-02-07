using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberWars
{
    class Program
    {
        public static Queue<string> firstPlayerCards;
        public static Queue<string> secondPlayerCards;
        static void Main(string[] args)
        {
            GetInput();
            string result = PlayTheGame();
        }

        private static string PlayTheGame()
        {
            while (true)
            {
                List<string> firstPlayerCardsOnTable = new List<string>();
                List<string> secondPlayerCardsOnTable = new List<string>();
                firstPlayerCardsOnTable.Add(firstPlayerCards.Dequeue());
                secondPlayerCardsOnTable.Add(secondPlayerCards.Dequeue());
                if ()
                {

                }
               
            }
            throw new NotImplementedException();
        }

        private static void GetInput()
        {
            var firstHandInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var secondHandInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
             firstPlayerCards = new Queue<string>(firstHandInput);
             secondPlayerCards = new Queue<string>(secondHandInput);
        }
    }
}
