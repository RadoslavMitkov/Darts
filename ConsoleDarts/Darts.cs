using System;
using System.Collections.Generic;

namespace ConsoleDarts
{
    class Darts
    {
        static void Main(string[] args)
        {
            Console.Write("Въведи броя на играчите: ");

            var input = Console.ReadLine();

            var players = new List<Player>();
            int playersCount;

            while (!int.TryParse(input, out playersCount))
            {
                Console.WriteLine("Броят на играчите трябва да е число!");
                Console.Write("Въведи броя на играчите: ");

                input = Console.ReadLine();
            }

            if (playersCount > 10)
            {
                Console.WriteLine("Честита Ви сватба!?");
            }

            for (int i = 1; i <= playersCount; i++)
            {
                var player = new Player();

                Console.Write($"Въведи име на играч {i}: ");

                player.Name = Console.ReadLine();

                players.Add(player);
            }

            Console.WriteLine();
            Console.WriteLine("Играта започва!");

            while (true)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    var currPlayer = players[i];

                    Console.WriteLine();
                    Console.WriteLine($"{currPlayer.Name} е на ред.");
                    Console.WriteLine($"Остават ти - {currPlayer.Points}");
                    Console.Write("Въведи си точките: ");

                    var inputPoints = Console.ReadLine();
                    int currPoints;

                    while (true)
                    {
                        var isParsed = int.TryParse(inputPoints, out currPoints);

                        if (isParsed)
                        {
                            if (currPoints > 180)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Точките трябва да са по-малко от 180!");
                                Console.Write("Въведи си точките: ");

                                inputPoints = Console.ReadLine();
                                isParsed = int.TryParse(inputPoints, out currPoints);
                            }

                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Точките трябва да са число!");
                            Console.Write("Въведи си точките: ");

                            inputPoints = Console.ReadLine();
                        }
                    }

                    if (currPlayer.Points - currPoints >= 0)
                    {
                        currPlayer.Points -= currPoints;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Ха, не уцели!");
                    }

                    if (currPlayer.Points == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Победител е {currPlayer.Name}!");
                        Console.WriteLine();

                        foreach (var player in players)
                        {
                            Console.WriteLine($"{player.Name} с {player.Points} точки.");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Натисни Enter за да излезеш...");
                        Console.ReadLine();

                        return;
                    }
                }
            }
        }
    }
}
