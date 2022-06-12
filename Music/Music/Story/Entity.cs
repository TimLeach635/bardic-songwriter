using System.Collections.Generic;
using Music.Lyrics;

namespace Music.Story
{
    public class Entity
    {
        public virtual Word Noun { get; set; }

        public List<Quality> Qualities { get; set; }
    }
}
