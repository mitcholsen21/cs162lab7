using System.Collections;
using System.Collections.Generic;

public abstract class Train : IEnumerable<Domino>
{
    protected List<Domino> dominos;
    public int? EngineValue { get; private set; }

    public Train()
    {
        dominos = new List<Domino>();
        EngineValue = null;
    }

    public Train(int engineValue)
    {
        dominos = new List<Domino>();
        EngineValue = engineValue;
    }

    public int Count => dominos.Count;
    public bool IsEmpty => dominos.Count == 0;
    public Domino LastDomino => IsEmpty ? null : dominos[dominos.Count - 1];
    public int PlayableValue => IsEmpty ? (EngineValue ?? 0) : LastDomino.Side2;

    public Domino GetDominoAt(int index)
    {
        if (index < 0 || index >= dominos.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        return dominos[index];
    }

    public bool IsDominoPlayable(Domino domino, out bool mustBeFlipped)
    {
        mustBeFlipped = false;
        if (domino.Side1 == PlayableValue)
        {
            return true;
        }
        if (domino.Side2 == PlayableValue)
        {
            mustBeFlipped = true;
            return true;
        }
        return false;
    }

    public void PlayDomino(Domino domino)
    {
        if (!IsDominoPlayable(domino, out bool mustBeFlipped))
        {
            throw new InvalidOperationException("The domino is not playable on this train.");
        }

        if (mustBeFlipped)
        {
            domino.Flip();
        }

        dominos.Add(domino);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("Train: ");
        foreach (var domino in dominos)
        {
            sb.Append(domino.ToString());
            sb.Append(" ");
        }
        return sb.ToString().Trim();
    }

    public abstract bool IsPlayable(Domino domino, List<Domino> hand, out bool mustBeFlipped);

    public IEnumerator<Domino> GetEnumerator()
    {
        return dominos.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


