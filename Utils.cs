namespace fishing_game;

class Utils
{

    public static void ShowOptionsFromMenu(string menu)
    {
        Constants.Menus[menu].ForEach(menu => Console.WriteLine(menu));
    }

    public static void ShowFishPool(List<Fish> fishes)
    {
        Console.WriteLine("Fish pool with:");
        fishes.ForEach(fish =>
        {
            Console.WriteLine($"{fish.Name} ${fish.MarketPrice} with {fish.BiteProbability}% be caught");
        });
    }

    public static bool IsValidInput(string input, int total)
    {
        if (string.IsNullOrEmpty(input)) return false;

        if (int.TryParse(input, out int result))
        {
            if (result >= 1 && result <= total) return true;
        }

        return false;
    }

    public static int CalculateFishMarketPrice(List<Fish> fishList)
    {
        int totalPrice = 0;

        fishList.ForEach(fish => totalPrice += fish.MarketPrice);

        return totalPrice;
    }

    public static void ShowFullFish(List<Fish> fishes)
    {
        Console.WriteLine("We're full! Let's look at what we caught.");

        // print all fish
        fishes.ForEach(fish => Console.WriteLine(fish.Name));

        Console.WriteLine(Constants.BlankLine);
    }

}