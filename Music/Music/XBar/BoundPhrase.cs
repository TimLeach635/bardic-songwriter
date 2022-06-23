using System.Collections.Generic;
using Music.Lyrics;
using Music.Story;

namespace Music.XBar
{
    /**
    A "bound phrase" is a phrase bound to a specific story object,
    for example an event, action, character, or object.
    */
    public abstract class BoundPhrase<T> : Phrase, IMutableTowardsPattern
    {
        public T StoryObject { get; set; }

        public BoundPhrase(T storyObject, Lexeme head, Phrase specifier, Phrase complement) : base(head, specifier, complement)
        {
            StoryObject = storyObject;
        }

        public BoundPhrase(T storyObject, Lexeme head, Phrase specifier, Phrase complement, ICollection<Phrase> adjuncts) : base(head, specifier, complement, adjuncts)
        {
            StoryObject = storyObject;
        }

        public abstract void MutateTowards(SyllablePattern target);
    }
}
