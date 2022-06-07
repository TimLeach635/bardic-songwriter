using Music.Lyrics;

namespace Music.Story
{
    public class Action
    {
        public Verb Verb { get; }

        public override string ToString()
        {
            return $"Action: \"{Verb.PresentParticiple}\"";
        }
    }
}
