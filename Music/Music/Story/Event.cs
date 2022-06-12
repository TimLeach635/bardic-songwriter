using Music.Song;

namespace Music.Story
{
    /**
    An "event" is the top level thing taken from the adventure.
    The rationale for this is that the song is always supposed
    to describe the adventure in a storytelling way, so the actual
    events that occured are the most important things.
    Each event has a value judgment associated with it ("good" or "bad")
    to aid our choice of the words we use to describe the event.
    For example, a hero attacking a monster is a good thing, so we might say
    "The valiant adventurer cleft the monster in twain", but
    a monster attacking a hero is a bad thing, so we might instead say
    "The hideous monster wounded our brave hero with its disgusting claws".
    We're writing bardic songs here, so we can genuinely simplify
    it down to "good" and "bad"!
    */
    public class Event
    {
        public Morality Morality { get; set; }
        public Action Action { get; set; }
        // The entity who performed the action
        public Entity Subject { get; set; }
        // The entity to whom the action was performed
        public Entity Object { get; set; }
        // The entity with which the action was performed
        public Entity Implement { get; set; }

        public string MatchToPattern(Pattern pattern)
        {
            if (Implement is not null)
            {
                return $"{Subject.Noun} {Action.Verb.PastParticiple} {Object.Noun} with {Implement.Noun}";
            }
            return $"{Subject.Noun} {Action.Verb.PastParticiple} {Object.Noun}";
        }
    }
}
