using System.Collections.Generic;

namespace Music.Story
{
    public class StoryEvents
    {
        public List<Event> Events { get; }

        public StoryEvents(List<Event> events)
        {
            Events = events;
        }
    }
}
