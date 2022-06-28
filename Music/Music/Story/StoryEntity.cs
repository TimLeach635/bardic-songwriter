using Music.Lyrics;

namespace Music.Story
{
    public class StoryEntity
    {
        public Noun Noun { get; }

        public StoryEntity(Noun noun)
        {
            Noun = noun;
        }

        public StoryEntity(string noun) : this(new Noun(noun)) { }
    }
}
