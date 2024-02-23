namespace Keywords
{
    public class Word
    {
        public string SP { get; set; }
        public string EN { get; set; }
        public int Points { get; set; }

        public Word(string SP, string EN)
        {
            this.SP = SP;
            this.EN = EN;
        }
    }
}
