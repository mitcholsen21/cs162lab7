public class SimpleTrain : Train
{
    public SimpleTrain() : base() { }
    public SimpleTrain(int engineValue) : base(engineValue) { }

    public override bool IsPlayable(Domino domino, List<Domino> hand, out bool mustBeFlipped)
    {
        return IsDominoPlayable(domino, out mustBeFlipped);
    }
}

class Program
{
    static void Main(string[] args)
    {
        SimpleTrain train = new SimpleTrain(6);
        Domino d1 = new Domino(6, 1);
        Domino d2 = new Domino(1, 2);

        Console.WriteLine(train); // Should print "Train:"

        train.PlayDomino(d1);
        Console.WriteLine(train); // Should print "Train: [6|1]"

        train.PlayDomino(d2);
        Console.WriteLine(train); // Should print "Train: [6|1] [1|2]"

        Console.WriteLine($"Count: {train.Count}"); // Should print "Count: 2"
        Console.WriteLine($"Engine Value: {train.EngineValue}"); // Should print "Engine Value: 6"
        Console.WriteLine($"Is Empty: {train.IsEmpty}"); // Should print "Is Empty: False"
        Console.WriteLine($"Last Domino: {train.LastDomino}"); // Should print "Last Domino: [1|2]"
        Console.WriteLine($"Playable Value: {train.PlayableValue}"); // Should print "Playable Value: 2"

        // Testing IsDominoPlayable
        Domino d3 = new Domino(3, 2);
        if (train.IsDominoPlayable(d3, out bool mustBeFlipped))
        {
            Console.WriteLine($"Domino {d3} is playable and must be flipped: {mustBeFlipped}");
        }
        else
        {
            Console.WriteLine($"Domino {d3} is not playable");
        }

        // Test exception for non-playable domino
        try
        {
            Domino d4 = new Domino(5, 4);
            train.PlayDomino(d4);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message); // Should print an error message
        }
    }
}

