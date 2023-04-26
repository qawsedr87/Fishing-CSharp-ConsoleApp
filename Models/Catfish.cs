namespace fishing_game;

class Catfish : Fish
{
    public Catfish(int probability) : base(probability)
    {
        MarketPrice = 10;
        Name = "catfish";
    }

}
