namespace fishing_game;

class Constants
{
    public const string BlankLine = "\n\n\n";
    public const string InvalidInputMessage = "Invalid input. Please enter a number from 1 to {0}." + BlankLine;

    public const string NoFishToSellMessage = "You have no fish. Come back when you have something to sell.";

    public const string OutOfPriceMessage = "Sorry, {0} is out of your price range. Try another rod.";
    public const string AfterBuyingRodMessage = "Congratulations, you are the new owner of {0}";
    public const string BalanceMessage = "You have ${0}.";

    public const string SellingFishMessage = "You made ${0} from your fish.";

    public static readonly Dictionary<string, List<string>> Menus = new Dictionary<string, List<string>>() {
       {
            "Welcome",
            new List<string>() {
                "Welcome to deep sea fishing!",
                "------------"
            }
       },
       {
            "Main",
            new List<string>() {
                "1. Go fishing",
                "2. Bass pro shop",
                "3. Sell fish",
                "What would you like to do?"
            }
       },
       {
            "Lake",
            new List<string>() {
                "Which lake would you like to go to?"
            }
       }
    };
}
