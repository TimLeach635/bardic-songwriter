using Music.Lyrics;

namespace Music.Story
{
    public class Event
    {
        // The entity who performed the action
        private Entity _subject;
        private ThirdPersonSimplePastVerb _verb;
        // The entity to whom the action was performed
        private Entity _object;

        public Event(Entity verbSubject, ThirdPersonSimplePastVerb verb, Entity verbObject)
        {
            _subject = verbSubject;
            _verb = verb;
            _object = verbObject;
        }

        public string GenerateLyrics()
        {
            string capitalisedSubject =
                _subject.Noun.ToString().Substring(0, 1).ToUpper()
                + _subject.Noun.ToString().Substring(1);
            return $"{capitalisedSubject} {_verb} {_object.Noun}";
        }
    }
}
