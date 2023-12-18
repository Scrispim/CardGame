using BlakJack.Util;

namespace BlakJack.Domain{

public class Deck
{
    private List<Card> cards;
    private Random random;

    public Deck()
    {
        cards = new List<Card>();
        random = new Random();

        // Initialize the deck with all cards
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card(suit, rank));
            }
        }
    }

    public void Shuffle()
    {
        // Fisher-Yates shuffle algorithm
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card DrawCard()
    {
        // Remove and return the top card from the deck
        if (cards.Count > 0)
        {
            Card drawnCard = cards[0];
            cards.RemoveAt(0);
            return drawnCard;
        }
        else
        {
            // Reinitialize the deck if it's empty
            cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }
            Shuffle(); // Shuffle the reinitialized deck
            return DrawCard(); // Draw a card from the shuffled deck
        }
    }
}

}