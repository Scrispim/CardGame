using BlakJack.Util;

namespace BlakJack.Domain{

public class Card
{
    public Suit Suit { get; }
    public Rank Rank { get; }

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public int GetValue()
    {
        // Face cards (King, Queen, Jack) are worth 10
        if (Rank == Rank.King || Rank == Rank.Queen || Rank == Rank.Jack)
        {
            return 10;
        }
        // Aces are initially worth 11, but their value can be reduced to 1 if needed
        else if (Rank == Rank.Ace)
        {
            return 11;
        }
        // Other cards are worth their face value
        else
        {
            return (int)Rank;
        }
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}


}