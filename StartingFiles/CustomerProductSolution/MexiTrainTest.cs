using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Testing MexicanTrain
        MexicanTrain mexicanTrain = new MexicanTrain(6);
        Domino d1 = new Domino(6, 1);
        Domino d2 = new Domino(1, 2);

        Console.WriteLine("Testing MexicanTrain");
        mexicanTrain.PlayDomino(d1);
        mexicanTrain.PlayDomino(d2);
        Console.WriteLine(mexicanTrain); // Should print "Train: [6|1] [1|2]"

        Domino d3 = new Domino(3, 2);
        if (mexicanTrain.IsPlayable(d3, new List<Domino>(), out bool mustBeFlipped))
        {
            Console.WriteLine($"Domino {d3} is playable and must be flipped: {mustBeFlipped}");
        }
        else
        {
            Console.WriteLine($"Domino {d3} is not playable");
        }

        // Testing PlayerTrain
        List<Domino> playerHand = new List<Domino> { new Domino(2, 5), new Domino(5, 6) };
        PlayerTrain playerTrain = new PlayerTrain(playerHand, 6);

        Console.WriteLine("Testing PlayerTrain");
        playerTrain.PlayDomino(new Domino(6, 4));
        Console.WriteLine(playerTrain); // Should print "Train: [6|4]"

        Domino d4 = new Domino(4, 5);
        if (playerTrain.IsPlayable(d4, playerHand, out mustBeFlipped))
        {
            playerTrain.PlayDomino(d4);
            Console.WriteLine(playerTrain); // Should print "Train: [6|4] [4|5]"
        }

        playerTrain.Open();
        Domino d5 = new Domino(5, 3);
        if (playerTrain.IsPlayable(d5, playerHand, out mustBeFlipped))
        {
            playerTrain.PlayDomino(d5);
            Console.WriteLine(playerTrain); // Should print "Train: [6|4] [4|5] [5|3]"
        }

        Console.WriteLine($"Is PlayerTrain open: {playerTrain.IsOpen}"); // Should print "Is PlayerTrain open: True"

        playerTrain.Close();
        Console.WriteLine($"Is PlayerTrain open: {playerTrain.IsOpen}"); // Should print "Is PlayerTrain open: False"
    }
}

