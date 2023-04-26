using System;
using System.Collections.Generic;
using System.Threading;

namespace fishing_game
{
    class Game
    {
        // FIXME
        private static int SELL_MONEY = 0;

        private static List<Fish> container = new List<Fish>();

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
                    new Yellowtail(15),

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

            string input = get_main_menu();

            choose_lake(all_lakes);

            bass_pro_shop(all_rods);
        }

        private static string get_main_menu()
        {

            Console.WriteLine("1. Go fishing");
            Console.WriteLine("2. Bass pro shop");
            Console.WriteLine("3. Sell fish");
            Console.WriteLine("What would you like to do?");

            string input = Console.ReadLine();

            // TODO: check input is in {1, 2, 3} or null or invaild value

            return input;

        }

        private static void choose_lake(List<Lake> lakes)
        {

            // show list of lakes
            for (int i = 0; i < lakes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {lakes[i].Name}");
            }

            string input = Console.ReadLine();

            int index = int.Parse(input) - 1;
            Lake lake = lakes[index];

            Console.WriteLine("\n\n\n");
            Console.WriteLine($"Welcome to Lake {lake.Name}");

            go_fishing(lake.Fishes);

        }

        private static void go_fishing(List<Fish> availableFishes)
        {
            int full_container = 4;
            Random rand = new Random();

            // list of fishes in our container
            Console.WriteLine("Fish pool with:");
            availableFishes.ForEach(fish =>
            {
                Console.WriteLine($"{fish.Name} ${fish.MarketPrice} with {fish.BiteProbability}% be caught");
            });

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
            container.ForEach(fish => Console.WriteLine(fish.Name));

            Console.WriteLine("\n\n\n");
        }

        private static void bass_pro_shop(List<FishingRod> rods)
        {
            Console.WriteLine("Welcome to the Bass Pro shop!");
            Console.WriteLine(string.Format($"You have ${0}", SELL_MONEY));

            // Show list of rods
            for (int i = 0; i < rods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {rods[i].Name} for ${rods[i].Price}");
            }

            Console.WriteLine("5. Return to main menu");

            Console.WriteLine("What fishing rod would you like to buy?");

            string input = Console.ReadLine();

            // TODO: check input is in {1, 2, 3, 4, 5} or null or invaild value

        }

        private static void sell_fish()
        {

            while (container.Count < 1)
            {
                Console.WriteLine("You have no fish. Come back when you have something to sell.");
                get_main_menu();
            }

            // TODO
        }
    }

}
