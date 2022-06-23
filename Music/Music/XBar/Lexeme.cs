using Music.Lyrics;

namespace Music.XBar
{
    public class Lexeme
    {
        public Word Word { get; }
        public LexemeCategory Category { get; }

        public Lexeme(Word word, LexemeCategory category)
        {
            Word = word;
            Category = category;
        }

        public override string ToString()
        {
            return (Word is not null ? Word.ToString() : "Ø");
        }
    }
}
