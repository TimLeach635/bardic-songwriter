using Music.Lyrics;

namespace Music.Story
{
    public class Action
    {
        public Verb Verb { get; set; }

        public override string ToString()
        {
            return $"Action: \"{Verb.PresentParticiple}\"";
        }
    }
}
