using Data;
using Model;
using System.Linq;




int[] numbers = { 11, 2, 13, 44, -5, 6, 127, -99, 0, 256 };

// where filtrace
//var result = numbers.Where(x => x >= 1 && x <= 99);

//orderby řadí
//var result = numbers.OrderBy(n => n);

//Agregace min, max, sum, avg, count
//var result = numbers.Max();
//var result = numbers.Min();
//var result = numbers.Sum();
//var result = numbers.Average();
//var result = numbers.Count();

//Take, Skip (takewhile - bere dokud nenarazí na kladný výsledek podmínky, pak přestane)
//var result = numbers.TakeWhile(n => n > 0);

// Select - transformace
//var result = numbers.Select(n => Math.Abs(n));










foreach (int item in result)
{
    Console.WriteLine(item);
}


static void FreqWords()
{
    var booksdir = @"C:\Users\Student\source\repos\starburst2006\Books";

    var files = Directory.EnumerateFiles(booksdir, "*.txt");
    foreach (var file in files)
    {
        var result = FreqAnalysis.FreqAnalysisFromFile(file);
        var fileInfo = new FileInfo(file);

        Console.WriteLine(fileInfo.Name);

        var orderedTop10 = result.Words.OrderByDescending(kv => kv.Value).Take(10);

        foreach (var item in orderedTop10)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        Console.WriteLine();
    }
}