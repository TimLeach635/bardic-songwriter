using System.Collections.Generic;
using Music.Lyrics;

namespace Music.Story
{
    public class Entity
    {
        public Noun Noun { get; }

        public Entity(Noun noun)
        {
            Noun = noun;
        }

        public Entity(string noun) : this(new Noun(noun)) { }
    }
}
