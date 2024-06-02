public class PlayerTrain : Train
{
    public List<Domino> Hand { get; private set; }
    public bool IsOpen { get; private set; }

    public PlayerTrain(List<Domino> hand) : base()
    {
        Hand = hand;
        IsOpen = false;
    }

    public PlayerTrain(List<Domino> hand, int engineValue) : base(engineValue)
    {
        Hand = hand;
        IsOpen = false;
    }

    public override bool IsPlayable(Domino domino, List<Domino> hand, out bool mustBeFlipped)
    {
        // Check if the train is open or if the domino belongs to the player's hand
        if (IsOpen || Hand.Contains(domino))
        {
            return IsDominoPlayable(domino, out mustBeFlipped);
        }

        mustBeFlipped = false;
        return false;
    }

    public void Open()
    {
        IsOpen = true;
    }

    public void Close()
    {
        IsOpen = false;
    }
}

