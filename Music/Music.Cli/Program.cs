using System.Collections.Generic;
using Music.Story;
using Music.Lyrics;

namespace Music.Cli
{
    class Program
    {
        static void Main(string[] args)
        {

            Entity thorg = new Entity("Thorg");
            Entity ben = new Entity("Ben");
            Entity ang = new Entity("Ang");

            Entity snake = new Entity("the snake");
            Entity troll = new Entity("the troll");

            Entity forest = new Entity("the forest");

            StoryEvents story = new StoryEvents(new() {
                new Event(new Entity("the heroes"), new ThirdPersonSimplePastVerb("went to"), forest),
                new Event(snake, new ThirdPersonSimplePastVerb("bit"), thorg),
                new Event(ben, new ThirdPersonSimplePastVerb("healed"), thorg),
                new Event(thorg, new ThirdPersonSimplePastVerb("attacked"), troll),
            });

            foreach (Event storyEvent in story.Events)
            {  
                System.Console.WriteLine(storyEvent.GenerateLyrics());
            }
        }
    }
}
