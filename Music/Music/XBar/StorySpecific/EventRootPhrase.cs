using System;
using System.Collections.Generic;
using Music.Lyrics;
using Music.Story;

namespace Music.XBar
{
    public class EventRootPhrase : BoundPhrase<Event>
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

        public EventRootPhrase(Event storyEvent, Lexeme head, Phrase specifier, Phrase complement)
        : base(storyEvent, head, specifier, complement)
        { }

        public EventRootPhrase(Event storyEvent, Lexeme head, Phrase specifier, Phrase complement, ICollection<Phrase> adjuncts)
        : base(storyEvent, head, specifier, complement, adjuncts)
        { }

        public override void MutateTowards(SyllablePattern target)
        {

        }
    }
}
