using System.Collections.Generic;
using Music.Lyrics;

namespace Music.Story
{
    // A "quality" is just an attribute something can have, like
    // an axe being "sharp" and "made of steel",
    // a hero being "brave" or "quick to anger",
    // or a monster being "vicious" or "covered in spikes".
    public class Quality
    {
        public Word Adjective { get; set; }
        public List<Word> Homonyms { get; set; }
    }
}
