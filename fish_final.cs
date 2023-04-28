using System;
using System.Collections.Generic;
using System.Threading;

namespace fishing_game
{
    class Game
    {
        // FIXME
        private static int money = 0;

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

            // welcome menu
            Utils.ShowOptionsFromMenu("Welcome");

            while (true)
            {
                // main menu
                string input = get_main_menu();

                // menu
                if (input == "1") choose_lake(all_lakes);
                else if (input == "2") bass_pro_shop(all_rods);
                else if (input == "3") sell_fish();
            }
        }


        private static void SetFish(Fish fish)
        {
            container.Add(fish);
        }

        private static List<Fish> GetFish()
        {
            return container;
        }

        private static void ClearFish()
        {
            container = new List<Fish>();
        }

        private static void SetMoney(int amount)
        {
            money = amount;
        }

        private static int GetMoney()
        {
            return money;
        }

        private static string get_main_menu()
        {

            Utils.ShowOptionsFromMenu("Main");

            string input = Console.ReadLine();

            // if (string.IsNullOrEmpty(input)) return get_main_menu();

            if (!Utils.IsValidInput(input, 3))
            {
                Console.WriteLine(Constants.InvalidInputMessage, 3);
                return get_main_menu();
            }
            else
            {
                return input;
            }
        }

        private static void choose_lake(List<Lake> lakes)
        {
            // show lake menu
            Console.WriteLine(Constants.BlankLine);
            Utils.ShowOptionsFromMenu("Lake");

            // show list of lakes
            for (int i = 0; i < lakes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {lakes[i].Name}");
            }

            string input = Console.ReadLine();

            if (!Utils.IsValidInput(input, lakes.Count))
            {
                Console.WriteLine(Constants.InvalidInputMessage, lakes.Count);
                return;

            }
            else
            {
                int index = int.Parse(input) - 1;
                Lake lake = lakes[index];

                Console.WriteLine(Constants.BlankLine);
                Console.WriteLine($"Welcome to {lake.Name}");

                go_fishing(lake.Fishes);
            }
        }

        private static void go_fishing(List<Fish> availableFishes)
        {
            int full_container = 4;
            Random rand = new Random();

            // list of fishes in our container
            // Utils.ShowFishPool(availableFishes);

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
                        SetFish(availableFishes[random_fish_index]);
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

            Console.WriteLine(Constants.BlankLine);
        }

        private static void bass_pro_shop(List<FishingRod> rods)
        {
            Console.WriteLine(Constants.BlankLine);
            Console.WriteLine("Welcome to the Bass Pro shop!");
            Console.WriteLine(Constants.BalanceMessage, GetMoney());

            // Show list of rods
            for (int i = 0; i < rods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {rods[i].Name} for ${rods[i].Price}");
            }

            int totalOptions = rods.Count + 1;

            Console.WriteLine($"{totalOptions}. Return to main menu");

            Console.WriteLine("What fishing rod would you like to buy?");

            string input = Console.ReadLine();

            if (!Utils.IsValidInput(input, totalOptions))
            {
                Console.WriteLine(Constants.InvalidInputMessage, totalOptions);
                bass_pro_shop(rods);
            }
            else
            {
                buy_pro(rods, int.Parse(input) - 1);
            }
            return;
        }

        private static void buy_pro(List<FishingRod> rods, int index)
        {
            if (index == rods.Count) return;

            // buy rod 
            FishingRod rod = rods[index];

            if (GetMoney() < rod.Price)
            {
                Console.WriteLine(Constants.OutOfPriceMessage, rod.Name);
            }
            else
            {

                SetMoney(GetMoney() - rod.Price);

                Console.WriteLine(Constants.AfterBuyingRodMessage, rod.Name, rod.Price);
                Console.WriteLine(Constants.BalanceMessage, GetMoney());
            }

            bass_pro_shop(rods);
        }


        private static void sell_fish()
        {
            Console.WriteLine(Constants.BlankLine);

            // check if has fish  
            if (GetFish().Count == 0)
            {
                Console.WriteLine(Constants.NoFishToSellMessage);
                // get_main_menu();
                return;
            }
            else
            {
                // sell 
                int totalPrice = Utils.CalculateFishMarketPrice(GetFish());

                // set money 
                SetMoney(GetMoney() + totalPrice);
                Console.WriteLine(Constants.SellingFishMessage, totalPrice);

                // clear container
                ClearFish();
            }
        }
    }

}
