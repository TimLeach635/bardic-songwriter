using Music.Lyrics;

namespace Music.XBar
{
    public class Lexeme
    {
        public Word Word { get; }
        public Category Category { get; }

        public Lexeme(Word word, Category category)
        {
            Word = word;
            Category = category;
        }
    }
}
