using System.Collections.Generic;

namespace Music.XBar
{
    public class Adjunct : Phrase
    {
        public AdjunctCategory AdjunctCategory { get; set; }

        public Adjunct(AdjunctCategory category, Lexeme head, Phrase specifier, Phrase complement) : base(head, specifier, complement)
        {
            AdjunctCategory = category;
        }
        public Adjunct(AdjunctCategory category, Lexeme head, Phrase specifier, Phrase complement, ICollection<Phrase> adjuncts) : base(head, specifier, complement, adjuncts)
        {
            AdjunctCategory = category;
        }
    }
}
