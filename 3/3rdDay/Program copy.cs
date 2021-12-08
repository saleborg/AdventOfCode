// See https://aka.ms/new-console-template for more information
using System.Text;
using Advent_of_Code_2021;

Console.WriteLine("Hello, World!");

StringBuilder gamma = new StringBuilder();

var zeros = 0;
var ones = 0;

var lines = System.IO.File.ReadLines(@"C:\Code\AdventOfCode\3\input.txt").ToList<string>();
for (int i = 0; i < 12; i++)
{
    foreach (var line in lines)
    {
        if (Int32.Parse(line[i].ToString()) == 0)
        {
            zeros++;
        }
        else
        {
            ones++;
        }


    }
    if (zeros > ones)
    {
        gamma.Append("0");
    }
    else
    {
        gamma.Append("1");
    }
    zeros = 0;
    ones = 0;
}


//Console.WriteLine(gamma);

var gammaBin = Convert.ToInt32(gamma.ToString(), 2).ToString();
Console.WriteLine("GammaDec " + gammaBin);

StringBuilder epsilon = new StringBuilder();

foreach (var c in gamma.ToString().ToArray())
{
    if (c.Equals(char.Parse("0")))
    {
        epsilon.Append("1");
    }
    else
    {
        epsilon.Append("0");
    }
}

//Console.WriteLine("Epsilon " + epsilon);
var epsilonBin = Convert.ToInt32(epsilon.ToString(), 2).ToString();
//Console.WriteLine("Epsilon " + epsilonBin);

Console.WriteLine(Int32.Parse(gammaBin) * Int32.Parse(epsilonBin));


//Oxygen
var oxygen = Runner(lines, 0, true);
var oxygenBin = Convert.ToInt32(oxygen.ToString(), 2).ToString();
Console.WriteLine("OxygenBin: " + oxygenBin);
var co2 = Runner(lines, 0, false);
var co2Bin = Convert.ToInt32(co2.ToString(), 2).ToString();
Console.WriteLine("co2Bin: " + co2Bin);

Console.WriteLine(Int32.Parse(oxygenBin) * Int32.Parse(co2Bin));

string Runner(List<string> list, int loop, bool oxygen)
{

    var onesList = new List<string>();
    var zeroList = new List<string>();
    string i = handleIfOnly2(list, oxygen);
    if (!i.Equals(String.Empty))
    {
        return i;
    }

    putIntoLists(list, loop, onesList, zeroList);

    if (oxygen)
    {
        return handleOxygen(list, loop, oxygen, onesList, zeroList);
    }
    else
    {
        return handleco2(list, loop, oxygen, onesList, zeroList);
    }

}

string handleIfOnly2(List<string> list, bool oxygen)
{
    if (list.Count == 2)
    {
        var item = list[0];
        if (oxygen)
        {
            Console.WriteLine(item[11]);
            if (item[11].Equals("1"))
            {
                Console.WriteLine("Returning 1 in end " + item);
                return item;
            }
            else
            {
                Console.WriteLine("Returning 1 in end1   " + list[1]);
                return list[1];
            }
        }
        else
        {
            if (item[11].Equals("0"))
            {
                Console.WriteLine("Returning 0 in end" + item);
                return item;
            }
            else
            {
                Console.WriteLine("Returning 0 in end1" + item);
                return list[1];
            }
        }
    }
    return "";

}

string handleco2(List<string> list, int loop, bool oxygen, List<string> onesList, List<string> zeroList)
{
    try
    {
        if (onesList.Count == zeroList.Count)
        {
            Console.WriteLine("Add zerolist Same count");
            list.AddRange(zeroList);
        }
        list = new List<string>();
        if (onesList.Count > zeroList.Count)
        {
            list.AddRange(zeroList);
        }
        else
        {
            list.AddRange(onesList);
        }

        loop++;
        return Runner(list, loop, oxygen);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
    return "";
}

string handleOxygen(List<string> list, int loop, bool oxygen, List<string> onesList, List<string> zeroList)
{
    try
    {
        list = new List<string>();
        Console.WriteLine("OneList " + onesList.Count);
        Console.WriteLine("ZeroList " + zeroList.Count);
        if (onesList.Count == zeroList.Count)
        {
            Console.WriteLine("Add onelist Same count");
            list.AddRange(onesList);
        }


        if (onesList.Count > zeroList.Count)
        {

            Console.WriteLine("Add onelist");
            list.AddRange(onesList);
        }
        else
        {

            Console.WriteLine("Add zerolist");
            list.AddRange(zeroList);
        }

        loop++;
        return Runner(list, loop, oxygen);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
    return "";
}

void putIntoLists(List<string> list, int loop, List<string> onesList, List<string> zeroList)
{

    foreach (var item in list)
    {
        if (item.Substring(loop, 1).Equals("1"))
        {
            onesList.Add(item);
        }
        else
        {
            zeroList.Add(item);
        }
    }
}

new Day3().Part1();
new Day3().Part2();