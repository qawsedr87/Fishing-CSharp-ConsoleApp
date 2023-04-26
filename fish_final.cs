using System;
using System.Collections.Generic;
using System.Threading;

namespace fishing_game
{
    class Game
    {
        static void Main(string[] args)
        {
            /* KEEP THIS START */

            // list of lakes
            List<Lake> all_lakes = new List<Lake>()
            {
                // each lake takes in a list of fish that's available in the lake
                new Lake("Lake Tahoe", new List<Fish>()
                {
                    // each fish takes in the probability they bite the bait. So catfish has 35% chance of biting
                    new Catfish(35),

                    // albacore has 20% chance of biting
                    new Albacore(20),

                    // bluefin has 5% chance of biting
                    new Bluefin(5)

                }),
                // each lake takes in a list of fish that's available in the lake
                new Lake("Big Bear lake", new List<Fish>()
                {
                    // catfish less prolific in big bear, only 30% chance of biting.
                    new Catfish(30),

                    // albacore has 35% chance of biting
                    new Albacore(35),

                    // yellowtail has 15% chance of biting
                    new YellowTail(15),

                })
            };

            // list of all fishing rods available at the store
            List<FishingRod> all_rods = new List<FishingRod>()
            {
                // each fishing rod passes in the name, price, and buff added to probability.
                new FishingRod("Swift Model E", 50, 2),
                new FishingRod("Perry Water Eye Gouger", 200, 6),
                new FishingRod("The Senator", 400, 10),
                new FishingRod("Ocean Depleter", 1000, 20),

            };
            /* KEEP THIS END */


            Console.WriteLine("Welcome to deep sea fishing!");
            Console.WriteLine("---------");

            Console.WriteLine("1. Go fishing");
            Console.WriteLine("2. Bass pro shop");
            Console.WriteLine("3. Sell fish");
            Console.WriteLine("What would you like to do?");

            string input = Console.ReadLine();

        }



        private static void go_fishing(List<Fish> availableFishes)
        {
            int full_container = 4;
            Random rand = new Random();

            // list of fishes in our container


            Console.WriteLine(string.Format("Our container holds {0} fish. Keep the ones you love.", full_container));
            Console.WriteLine("Let's fish!");

            // while we have space in our container...
            while (container.Count < full_container)
            {

                // a random fish comes near our bait
                int random_fish_index = rand.Next(availableFishes.Count);

                // generate random number to see if fish bites bait
                int fish_bites_chance = rand.Next(100);

                // random chance if fish decides to bite the bait
                if (availableFishes[random_fish_index].BitesBait(fish_bites_chance))
                {

                    // Fishing techniques
                    Console.WriteLine("\nA fish bit your bait! What do you want to do?");
                    Console.WriteLine("1. Reel in fish");
                    Console.WriteLine("2. Use net\n");

                    string input = Console.ReadLine();

                    // if the user properly caught the fish...
                    if (availableFishes[random_fish_index].IsCaught(input))
                    {
                        Console.WriteLine("\nGot it! Let's see what we caught.");

                        // print the name of the fish
                        Console.WriteLine(availableFishes[random_fish_index].Name);
                        Console.WriteLine("");

                        // add fish to container
                        container.Add(availableFishes[random_fish_index]);
                    }
                    else
                    {
                        Console.WriteLine("Oh no! The fish got away. Keep trying!\n\n");
                    }
                }
                else
                {
                    Console.WriteLine("One minute went by...");
                    Thread.Sleep(500);
                }
            }

            Console.WriteLine("We're full! Let's look at what we caught.");

            // print all fish


            Console.WriteLine("\n\n\n");
        }
    }



    /// <summary>
    /// Base fish class
    /// </summary>
    class Fish
    {

        public string Name { get; set; }
        public int MarketPrice { get; set; }
        public int BiteProbability { get; set; }

        public Fish(int probability)
        {
            BiteProbability = probability;
        }

        /// <summary>
        /// Random chance at fish biting bait
        /// </summary>
        /// <returns><c>true</c>, if bait was bitten, <c>false</c> otherwise.</returns>
        internal virtual bool BitesBait(int chance)
        {
            if (chance < BiteProbability)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Each fish needs to be caught using the proper technique. 
        /// </summary>
        /// <returns><c>true</c>, if fish was caught, <c>false</c> otherwise.</returns>
        /// <param name="input">Input.</param>
        internal bool IsCaught(string input)
        {
            if (input == "1")
            {
                return true;
            }
            return false;
        }
    }

    class Catfish : Fish
    {
        public Catfish(int probability) : base(probability)
        {
            MarketPrice = 10;
            Name = "catfish";
        }

    }

}
