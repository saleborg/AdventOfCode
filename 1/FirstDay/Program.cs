using System.Collections;
using System.Linq;




// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int counter = 0;
int lastNumber = 0;

int threeNumberCount = 0;
var sumsOfThree = new List<int>();
// Read the file and display it line by line. 
System.Collections.Generic.IEnumerable<string> lines = System.IO.File.ReadLines(@"C:\Code\AdventOfCode\1\FirstDay\input.txt");
List<string> asList = lines.ToList();

for (int i = 0; i < asList.Count; i++)
{
    if (asList.Count - i > 3)
    {
        int threeNumbersSum = 0;
        threeNumbersSum += Int32.Parse(asList[i]);
        threeNumbersSum += Int32.Parse(asList[i + 1]);
        threeNumbersSum += Int32.Parse(asList[i + 2]);
        sumsOfThree.Add(threeNumbersSum);
    }

}

foreach (int i in sumsOfThree)
{
    if (i > lastNumber)
    {
        counter++;
    }
    lastNumber = i;



}
System.Console.WriteLine("SIZE: " + sumsOfThree.Count);


System.Console.WriteLine("There were {0} bigger.", counter);