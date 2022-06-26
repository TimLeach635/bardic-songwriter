namespace Music.Lyrics
{
    public class Noun
    {
        private string _word;

        public Noun(string word)
        {
            _word = word;
        }

        public override string ToString()
        {
            return _word;
        }
    }
}
