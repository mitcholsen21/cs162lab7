public class MexicanTrain : Train
{
    public MexicanTrain() : base() { }
    public MexicanTrain(int engineValue) : base(engineValue) { }

    public override bool IsPlayable(Domino domino, List<Domino> hand, out bool mustBeFlipped)
    {
        return IsDominoPlayable(domino, out mustBeFlipped);
    }
}

