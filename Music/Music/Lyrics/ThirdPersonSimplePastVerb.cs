namespace Music.Lyrics
{
    public class ThirdPersonSimplePastVerb
    {
        public string Word { get; }

        public ThirdPersonSimplePastVerb(string Word)
        {
            this.Word = Word;
        }

        public override string ToString()
        {
            return Word;
        }
    }
}
