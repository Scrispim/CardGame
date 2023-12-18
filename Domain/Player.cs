using BlakJack.Util;

namespace BlakJack.Domain{

public class Player
{
    public string Name { get; }
    private List<Card> hand;
    private bool isComputer;

    public static List<Player> CreatePlayers()
    {
        return new List<Player>
            {
                new Player("Mario"),
                new Player("Luidi"),
                new Player("Pitch"),
                new Player("DK"),
                new Player("King"),
                new Player("Computer", isComputer: true)
            };
    }
    public Player(string name, bool isComputer = false)
    {
        Name = name;
        hand = new List<Card>();
        this.isComputer = isComputer;
    }

    public void AddCard(Card card)
    {
        hand.Add(card);
    }

    public bool IsDrawing()
    {
        // Allow human players to decide whether to draw
        if (!isComputer)
        {
            Console.Write($"{Name}, do you want to draw another card? (y/n): ");
            return (Console.ReadLine().ToLower() == "y");
        }

        // Computer players draw until hand value is at least 17
        return (CalculateHandValue() < 17);
    }

    public int CalculateHandValue()
    {
        int value = 0;
        int numAces = 0;

        foreach (Card card in hand)
        {
            value += card.GetValue();

            // Count Aces separately to handle their flexible value
            if (card.Rank == Rank.Ace)
            {
                numAces++;
            }
        }

        // Adjust the value for Aces (if any)
        while (value > 21 && numAces > 0)
        {
            value -= 10; // Treat an Ace as 1 instead of 11
            numAces--;
        }

        return value;
    }

    public string GetHandDescription()
    {
        return string.Join(", ", hand);
    }
}

}