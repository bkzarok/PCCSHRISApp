namespace HRISApplication.Models.ChartModels
{
    public class WordCount
    {
     public string Word {  get; set; } 

     public int Count { get; set; }
    }


    class WordWordCount
    {
        public string Word { get; set; }

        public List<WordCount> WordCount {get; set;}
    }
}
