using System;
using System.Text;

class Program
{
    static int depth = 0;

    static int aim = 0;
    static int horizontalPosition = 0;
    static void Main(string[] args)
    {
        System.Collections.Generic.IEnumerable<string> lines = System.IO.File.ReadLines(@"C:\Code\AdventOfCode\2\input.txt");
        List<string> asList = lines.ToList();
        foreach (string i in asList)
        {
            var line = i.Trim();
            int direction = line.Length;
            switch (direction)
            {
                case 4:
                    //Up
                    handleUp(line);
                    break;
                case 6:
                    //Down
                    handleDown(line);
                    break;

                case 9:
                    //Forward
                    handleForward(line);
                    break;

                default:
                    System.Console.WriteLine("Error " + line);
                    break;

            }

            System.Console.WriteLine(depth);
            System.Console.WriteLine(horizontalPosition);
            System.Console.WriteLine(horizontalPosition * depth);


        }

    }

    private static void handleForward(string i)
    {
        int movment = Int32.Parse(i.Substring(8));
        horizontalPosition += movment;

        depth += (movment * aim);


    }

    private static void handleDown(string i)
    {

        aim += Int32.Parse(i.Substring(5));




    }

    private static void handleUp(string i)
    {

        aim -= Int32.Parse(i.Substring(3));

    }
}