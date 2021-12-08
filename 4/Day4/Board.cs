using System.Text;

public class Board
{

    public Number[,] Numbers = new Number[5, 5];

    public Board()
    {

    }

    public override String ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var n in Numbers)
        {
            sb.Append(n + " ");
        }

        return sb.ToString();
    }
}