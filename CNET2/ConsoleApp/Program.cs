using Data;
using Model;
using System.Linq;





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


//foreach (int item in result)
//{
//    Console.WriteLine(item);
//}



//int[] numbers = { 11, 2, 13, 44, -5, 6, 127, -99, 0, 256 };

//úkol 1: zjistěte počet kladných čísel
//var result = numbers.Where(x => x>=0).Count();
//Console.WriteLine(result);

//úkol 2: ignorujte největší a nejmenší číslo a ze zbytku vypočítej průměr
//var min = numbers.Min();
//var max = numbers.Max();
//var zbytek = numbers.Where(x => x != min && x != max);
//var avg = zbytek.Average();
//Console.WriteLine(avg);

//úkol 3: spočítat liché a sudé
//var liche = numbers.Where(x => x % 2 != 0).Count();
//var sude = numbers.Where(x => x % 2 == 0).Count();
//Console.WriteLine($"sudé: {sude}, liché: {liche}");


////úkol 4: vypište pole numbers pomocí slovního vyhádření z pole stringů 
//var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
//var strings = new[] { "zero", "one", "two", "three", "four",
//    "five", "six", "seven", "eight", "nine" };
//var result = numbers.Select(x => strings[x]);
//Console.WriteLine(string.Join(", ", result));

//Console.ReadKey();


//static void FreqWords()
//{
//    var booksdir = @"C:\Users\Student\source\repos\starburst2006\Books";

//    var files = Directory.EnumerateFiles(booksdir, "*.txt");
//    foreach (var file in files)
//    {
//        var result = FreqAnalysis.FreqAnalysisFromFile(file);
//        var fileInfo = new FileInfo(file);

//        Console.WriteLine(fileInfo.Name);

//        var orderedTop10 = result.Words.OrderByDescending(kv => kv.Value).Take(10);

//        foreach (var item in orderedTop10)
//        {
//            Console.WriteLine($"{item.Key}: {item.Value}");
//        }

//        Console.WriteLine();
//    }
//}