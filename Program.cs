using System;
using System.Collections.Generic;
using BlakJack.Domain;

public class Program
{
    public static void Main()
    {
        // Create players (including computer)
        List<Player> players = Player.CreatePlayers();

        // Create and shuffle a deck
        Deck deck = new Deck();
        deck.Shuffle();

        // Deal two initial cards to each player
        DealCards(ref players, ref deck);

        // Allow each player to draw cards until they choose to stop
        EachPlayerToDrawCards(ref players, ref deck);
        
        // Compare hands and determine the winner
        Player winner = DetermineWinner(players);

        // Display each player's final hand
        foreach (Player player in players)
        {
            Console.WriteLine($"{player.Name}'s Final Hand: {player.GetHandDescription()}");
        }

        // Declare the winner
        if (winner != null)
        {
            Console.WriteLine($"The winner is {winner.Name}!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }

    private static void DealCards(ref List<Player> players, ref Deck deck)
    {
       foreach (Player player in players)
        {
            player.AddCard(deck.DrawCard());
            player.AddCard(deck.DrawCard());
        }
    }

    private static void EachPlayerToDrawCards(ref List<Player> players, ref Deck deck)
    {
        foreach (Player player in players)
        {
            while (player.IsDrawing())
            {
                player.AddCard(deck.DrawCard());
                Console.WriteLine($"{player.Name}'s Hand: {player.GetHandDescription()}");
                if (player.CalculateHandValue() > 21)
                {
                    Console.WriteLine($"{player.Name} busts!");
                    break;
                }
            }
        }

    }

    private static Player DetermineWinner(List<Player> players)
    {
        Player winner = null;
        int highestValue = 0;

        foreach (Player player in players)
        {
            int handValue = player.CalculateHandValue();

            // Check for a valid hand (not busted)
            if (handValue <= 21)
            {
                // Update winner if the current player has a higher hand value
                if (handValue > highestValue)
                {
                    highestValue = handValue;
                    winner = player;
                }
            }
        }

        return winner;
    }
}

