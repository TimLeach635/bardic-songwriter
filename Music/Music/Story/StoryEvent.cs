using Music.Lyrics;

namespace Music.Story
{
    public class StoryEvent
    {
        // The entity who performed the action
        private StoryEntity _subject;
        private ThirdPersonSimplePastVerb _verb;
        // The entity to whom the action was performed
        private StoryEntity _object;

        public StoryEvent(StoryEntity verbSubject, ThirdPersonSimplePastVerb verb, StoryEntity verbObject)
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
