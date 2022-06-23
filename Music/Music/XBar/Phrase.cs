using System;
using System.Linq;
using System.Collections.Generic;

namespace Music.XBar
{
    public class Phrase
    {
        private static readonly Dictionary<LexemeCategory, string> CATEGORY_STRINGS = new()
        {
            { LexemeCategory.Noun, "N" },
            { LexemeCategory.Verb, "V" },
            { LexemeCategory.Adjective, "A" },
            { LexemeCategory.Preposition, "P" },
            { LexemeCategory.Inflection, "I" },
            { LexemeCategory.Adverb, "Adv" },
        };

        public virtual Lexeme Head { get; set; }
        public virtual Phrase Specifier { get; set; }
        public virtual Phrase Complement { get; set; }
        public virtual ICollection<Phrase> Adjuncts { get; set; }
        public virtual LexemeCategory Category => Head.Category;

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

        public override string ToString()
        {
            if (Adjuncts.Count == 0)
            {
                return $"[{CATEGORY_STRINGS[Category]}P {(Specifier is not null ? Specifier : "")} [{CATEGORY_STRINGS[Category]}' [{CATEGORY_STRINGS[Category]} {Head}] {(Complement is not null ? Complement : "")}]]";
            }
            if (Adjuncts.Count == 1)
            {
                return $"[{CATEGORY_STRINGS[Category]}P {(Specifier is not null ? Specifier : "")} [{CATEGORY_STRINGS[Category]}' [{CATEGORY_STRINGS[Category]}' [{CATEGORY_STRINGS[Category]} {Head}] {(Complement is not null ? Complement : "")}] {Adjuncts.Single()}]]";
            }
            throw new NotImplementedException("Haven't yet implemented the ToString() method for phrases with more than one adjunct");
        }
    }
}
