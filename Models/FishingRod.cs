namespace fishing_game;

class FishingRod {
    public string Name { get; set; }
    public int Price { get; set; }
    public int Buff { get; set; }

    public FishingRod(string name, int price, int buff) {
        Name = name;
        Price = price;
        Buff = buff;
    }

}