using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberWars
{
    class Program
    {


        static void Main(string[] args)
        {
            Queue<string> firstPlayerCards = GetInput();
            Queue<string> secondPlayerCards = GetInput();

            int turnCounter = 0;
            while (turnCounter < 1000000 && firstPlayerCards.Count != 0 && secondPlayerCards.Count != 0)
            {
                turnCounter++;
                if (getNumber(firstPlayerCards.Peek()) > getNumber(secondPlayerCards.Peek()))
                {
                    firstPlayerCards.Enqueue(firstPlayerCards.Dequeue());
                    firstPlayerCards.Enqueue(secondPlayerCards.Dequeue());
                    continue;
                }
                else if (getNumber(firstPlayerCards.Peek()) < getNumber(secondPlayerCards.Peek()))
                {
                    secondPlayerCards.Enqueue(secondPlayerCards.Dequeue());
                    secondPlayerCards.Enqueue(firstPlayerCards.Dequeue());
                    continue;
                }
                else if (getNumber(firstPlayerCards.Peek()) == getNumber(secondPlayerCards.Peek()))
                {
                    var dict = new Dictionary<int, List<string>>();
                    bool warWon = false;

                    dict = insertCards(dict, firstPlayerCards.Dequeue());
                    dict = insertCards(dict, secondPlayerCards.Dequeue());


                    while (!warWon && firstPlayerCards.Count >= 3 && secondPlayerCards.Count >= 3)
                    {
                        int sumOfFirstPLayerCards = GetSumOfCards(firstPlayerCards);
                        int sumOfSecondPlayerCards = GetSumOfCards(secondPlayerCards);
                        for (int i = 0; i < 3; i++)
                        {
                            dict = insertCards(dict, firstPlayerCards.Dequeue());

                            dict = insertCards(dict, secondPlayerCards.Dequeue());
                        }

                        if (sumOfFirstPLayerCards > sumOfSecondPlayerCards)
                        {
                            foreach (var cards in dict.OrderByDescending(x => x.Key))
                            {
                                foreach (var card in cards.Value.OrderByDescending(x => x))
                                {
                                    firstPlayerCards.Enqueue($"{cards.Key.ToString()}{card}");
                                    dict.Clear();
                                    warWon = true;
                                }

                            }
                        }
                        else if (sumOfFirstPLayerCards < sumOfSecondPlayerCards)
                        {
                            foreach (var cards in dict.OrderByDescending(x => x.Key))
                            {
                                foreach (var card in cards.Value.OrderByDescending(x => x))
                                {
                                    secondPlayerCards.Enqueue($"{cards.Key.ToString()}{card}");
                                    dict.Clear();
                                    warWon = true;
                                }

                            }
                        }

                    }

                }

            }

            if (turnCounter < 1000000)
            {
                if (firstPlayerCards.Count == secondPlayerCards.Count)
                {
                    Console.WriteLine($"Draw after {turnCounter} turns");
                }
                if (firstPlayerCards.Count < secondPlayerCards.Count)
                {
                    Console.WriteLine($"Second player wins after {turnCounter} turns");
                }
                else if (firstPlayerCards.Count > secondPlayerCards.Count)
                {
                    Console.WriteLine($"First player wins after {turnCounter} turns");
                }
            }
            else if (turnCounter >= 1000000)
            {
                if (firstPlayerCards.Count == secondPlayerCards.Count)
                {
                    Console.WriteLine($"Draw after {turnCounter} turns");
                }
                if (firstPlayerCards.Count < secondPlayerCards.Count)
                {
                    Console.WriteLine($"Second player wins after {turnCounter} turns");
                }
                else if (firstPlayerCards.Count > secondPlayerCards.Count)
                {
                    Console.WriteLine($"First player wins after {turnCounter} turns");
                }
            }

        }

        private static Dictionary<int, List<string>> insertCards(Dictionary<int, List<string>> dict, string input)
        {
            if (!dict.ContainsKey(int.Parse(input.Substring(0, input.Length - 1))))
            {
                dict.Add(int.Parse(input.Substring(0, input.Length - 1)), new List<string>());
                dict[int.Parse(input.Substring(0, input.Length - 1))].Add(input[input.Length - 1].ToString());
            }
            else
            {
                dict[int.Parse(input.Substring(0, input.Length - 1))].Add(input[input.Length - 1].ToString());
            }
            return dict;
        }

        private static int GetSumOfCards(Queue<string> handOfCard)
        {
            var sumQueue = new Queue<string>(handOfCard);
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                string card = sumQueue.Dequeue();
                sum += card[card.Length - 1];
            }
            return sum;
        }


        private static int getNumber(string card)
        {
            int number = int.Parse(card.Substring(0, card.Length - 1));
            return number;
        }

        private static Queue<string> GetInput()
        {
            var firstHandInput = Console.ReadLine().ToLower().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Queue<string> firstPlayerCards = new Queue<string>(firstHandInput);
            return firstPlayerCards;
        }
    }
}

