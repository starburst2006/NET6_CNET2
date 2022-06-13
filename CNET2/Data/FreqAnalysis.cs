

using Model;

namespace Data
{
    public class FreqAnalysis
    {
        public static Dictionary<string, int> FreqAnalysisFromString(string imput)
        {
            var result = new Dictionary<string, int>();
            var words = imput.Replace("."," ")
                             .Replace(",", " ")
                             .Replace("(", " ")
                             .Replace(")", " ")
                             .Replace(":", " ")
                             .Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var word in words)
            {
                if (result.ContainsKey(word))
                {
                    result[word]++;
                }
                else 
                { 
                    result.Add(word, 1);
                }
            }
            return result;
        }

        public static async Task<FAResult> FreqAnalysisFromUrl(string url)
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(url);
            var dict = FreqAnalysisFromString(content);
            return new FAResult()
            {
                Source = url,
                SourceType = SourceType.URL,
                Words = dict
            };
        }

        public static FAResult FreqAnalysisFromFile(string file)
        {
            var content = File.ReadAllText(file);
            var dict = FreqAnalysisFromString(content);
            return new FAResult()
            {
                Source = file,
                SourceType = SourceType.FILE,
                Words = dict
            };

        }


    }
}