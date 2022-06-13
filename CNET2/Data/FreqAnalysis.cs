namespace Data
{
    public class FreqAnalysis
    {
        public static Dictionary<string, int> FreqAnalysisFromString(string imput)
        {
            throw new NotImplementedException();  // nemám dopsáno, kompilátor mě nepustí zkompilovat, proto se dá obejít tímto zápisem...
        }

        public static async Task<Dictionary<string, int>> FreqAnalysisFromUrl(string url)
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(url);
            return FreqAnalysisFromString(content);
        }

        public static Dictionary<string, int> FreqAnalysisFromFile(string file)
        {
            var content = File.ReadAllText(file);
            return FreqAnalysisFromString(content);
        }


    }
}