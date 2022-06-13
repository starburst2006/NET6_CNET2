using Model;

Console.WriteLine("hello world");

FAResult fAResult = new FAResult("file",SourceType.FILE);


Console.WriteLine(fAResult);
fAResult.Words = new Dictionary<string, int>();

Console.WriteLine(fAResult);