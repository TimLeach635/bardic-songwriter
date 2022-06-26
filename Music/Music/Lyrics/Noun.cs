namespace Music.Lyrics
{
    public class Noun
    {
        public string Word { get; }

        public Noun(string word)
        {
            Word = word;
        }

        public override string ToString()
        {
            return Word;
        }
    }
}
