namespace Model
{
    /// <summary>
    /// Výsledek frekvenční analýzy pro jeden zdroj (soubor nebo URL)
    /// </summary>
    public class FAResult
    {
        public FAResult(string source, SourceType sourceType)
        {
            Source = source;
            SourceType = sourceType;
            Words = new Dictionary<string, int>();

        }

        /// <summary>
        /// zdroj textu
        /// </summary>
        public string Source { get; set; }
        public SourceType SourceType { get; set; }
        
        /// <summary>
        /// výsledná frekvenční analýza slov
        /// </summary>
        public Dictionary<string, int> Words { get; set; }

        public override string ToString()
        {
            return $"{Source} {Words?.Count}";
        }
    }

    public enum SourceType
    {
        URL,
        FILE
    }
}