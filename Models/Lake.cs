namespace fishing_game;

class Lake {
    public string Name { get; set; }

    public List<Fish> Fishes { get; set; }

    public Lake (string name, List<Fish> fishes) {
        Name = name;
        Fishes = fishes;
    }
}