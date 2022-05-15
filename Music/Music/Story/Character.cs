using System.Collections.Generic;
using Music.Lyrics;

namespace Music.Story
{
    public class Character
    {
        public Word Name { get; set; }
        public List<Word> PoeticNames { get; set; }
        public List<Word> Nouns { get; set; }
        public List<Word> Adjectives { get; set; }
        public List<Word> OffensivePossessions { get; set; }
        public List<Word> OffensivePossessionsPlural { get; set; }
        public List<Word> InfinitiveVerbs { get; set; }
        public List<Word> PreteriteVerbs { get; set; }
        public List<Word> PreteriteTransitiveVerbs { get; set; }
    }
}
