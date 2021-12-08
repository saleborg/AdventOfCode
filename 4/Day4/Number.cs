public class Number
{

    public Number(int value)
    {
        Value = value;
        Marked = false;
    }

    public int Value { get; }
    public bool Marked { get; set; }

    public override string ToString()
    {
        return Value.ToString(); ;
    }
}