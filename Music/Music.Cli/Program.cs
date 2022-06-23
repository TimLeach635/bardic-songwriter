using System.Collections.Generic;
using Music.Story;
using Music.Lyrics;

namespace Music.Cli
{
    class Program
    {
        static void Main(string[] args)
        {

            Character thorg = new Character { Name = new Word("Thorg", "S") };
            Entity axe = new Entity { Noun = new Word("axe", "S") };
            Character ben = new Character { Name = new Word("Ben", "S") };
            Entity staff = new Entity { Noun = new Word("staff", "S") };
            Character ang = new Character { Name = new Word("Ang", "S") };
            Entity bow = new Entity { Noun = new Word("bow", "S") };

            CharacterGroup adventurers = new CharacterGroup
            {
                Noun = new Word("the group", "sS"),
                Characters = new() { thorg, ben, ang }
            };

            Monster snake = new Monster(new Word("snake", "S"));
            Entity fangs = new Entity { Noun = new Word("fangs", "S") };
            Monster troll = new Monster(new Word("troll", "S"));
            Entity club = new Entity { Noun = new Word("club", "S") };

            Entity forest = new Entity { Noun = new Word("forest", "Ss") };

            StoryEvents story = new StoryEvents(new() {
                new Event
                {
                    Subject = adventurers,
                    Action = new Action
                    {
                        Verb = new Verb
                        {
                            Base = new Word("go to", "Ss"),
                            PastParticiple = new Word("went to", "Ss"),
                        },
                    },
                    Object = forest,
                },
                new Event
                {
                    Subject = snake,
                    Action = new Action
                    {
                        Verb = new Verb
                        {
                            Base = new Word("bite", "S"),
                            PastParticiple = new Word("bit", "S"),
                        },
                    },
                    Object = thorg,
                    Implement = fangs,
                },
                new Event
                {
                    Subject = ben,
                    Action = new Action
                    {
                        Verb = new Verb
                        {
                            Base = new Word("heal", "S"),
                            PastParticiple = new Word("healed", "S"),
                        },
                    },
                    Object = thorg,
                    Implement = staff,
                },
                new Event
                {
                    Subject = thorg,
                    Action = new Action
                    {
                        Verb = new Verb
                        {
                            Base = new Word("attack", "sS"),
                            PastParticiple = new Word("attacked", "sS"),
                        },
                    },
                    Object = troll,
                    Implement = axe,
                },
            });

            foreach (Event storyEvent in story.Events)
            {  
                System.Console.WriteLine(Converter.Convert(storyEvent));
            }
        }
    }
}
