using Music.Lyrics;

namespace Music.Story
{
    public class Character : Entity
    {
        public Word Name { get; set; }
        public override Word Noun => Name;
    }
}
