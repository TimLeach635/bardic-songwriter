using System.Collections.Generic;
using Music.Story;
using Music.Lyrics;

namespace Music.Cli
{
    class Program
    {
        static void Main(string[] args)
        {

            StoryEntity thorg = new StoryEntity("Thorg");
            StoryEntity ben = new StoryEntity("Ben");
            StoryEntity ang = new StoryEntity("Ang");

            StoryEntity snake = new StoryEntity("the snake");
            StoryEntity troll = new StoryEntity("the troll");

            StoryEntity forest = new StoryEntity("the forest");

            List<StoryEvent> story = new()
            {
                new StoryEvent(new StoryEntity("the heroes"), new ThirdPersonSimplePastVerb("went to"), forest),
                new StoryEvent(snake, new ThirdPersonSimplePastVerb("bit"), thorg),
                new StoryEvent(ben, new ThirdPersonSimplePastVerb("healed"), thorg),
                new StoryEvent(thorg, new ThirdPersonSimplePastVerb("attacked"), troll),
            };

            foreach (StoryEvent storyEvent in story)
            {  
                System.Console.WriteLine(storyEvent.GenerateLyrics());
            }
        }
    }
}
