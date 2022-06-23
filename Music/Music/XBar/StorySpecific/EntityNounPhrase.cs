using System;
using System.Collections.Generic;
using Music.Lyrics;
using Music.Story;

namespace Music.XBar
{
    public class EntityNounPhrase : BoundPhrase<Entity>
    {
        private Lexeme _head;
        public override Lexeme Head
        {
            get => _head;
            set
            {
                if (value.Category != LexemeCategory.Inflection)
                {
                    throw new ArgumentOutOfRangeException(
                        "value",
                        value,
                        "EventRootPhrases must be IPs, so their Head must be an inflection lexeme"
                    );
                }
            }
        }

        public EntityNounPhrase(Entity storyEntity, Lexeme head, Phrase specifier, Phrase complement)
        : base(storyEntity, head, specifier, complement)
        { }

        public EntityNounPhrase(Entity storyEntity, Lexeme head, Phrase specifier, Phrase complement, ICollection<Phrase> adjuncts)
        : base(storyEntity, head, specifier, complement, adjuncts)
        { }

        public override void MutateTowards(SyllablePattern target)
        {

        }
    }
}
