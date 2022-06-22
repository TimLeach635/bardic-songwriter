using System.Collections.Generic;
using Music.Lyrics;

namespace Music.XBar
{
    public class Phrase
    {
        public Lexeme Head { get; set; }
        public Phrase Specifier { get; set; }
        public Phrase Complement { get; set; }
        public ICollection<Phrase> Adjuncts { get; set; }
        public LexemeCategory Category => Head.Category;

        public Phrase(Lexeme head, Phrase specifier, Phrase complement)
        {
            Head = head;
            Specifier = specifier;
            Complement = complement;
            Adjuncts = new List<Phrase>();
        }

        public Phrase(Lexeme head, Phrase specifier, Phrase complement, ICollection<Phrase> adjuncts)
        {
            Head = head;
            Specifier = specifier;
            Complement = complement;
            Adjuncts = adjuncts;
        }
    }
}
