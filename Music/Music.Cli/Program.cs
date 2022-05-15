using System;
using Music.Story;
using Music.Lyrics;

namespace Music.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var thorg = new Character
            {
                Name = new Word("Al", new() { Stress.Stressed }),
                PoeticNames = new() {
                    new Word("strength", new() { Stress.Stressed }),
                },
                Nouns = new() {
                    new Word("brute", new() { Stress.Stressed }),
                },
                OffensivePossessions = new() {
                    new Word("belly", new() { Stress.Stressed, Stress.Unstressed }),
                    new Word("fists", new() { Stress.Stressed }),
                },
                OffensivePossessionsPlural = new() {
                    new Word("belly", new() { Stress.Stressed, Stress.Unstressed }),
                    new Word("fists", new() { Stress.Stressed }),
                },
                InfinitiveVerbs = new() {
                    new Word("wrest", new() { Stress.Stressed }),
                },
                PreteriteVerbs = new() {
                    new Word("leapt", new() { Stress.Stressed }),
                },
                PreteriteTransitiveVerbs = new() {
                    new Word("wrest", new() { Stress.Stressed }),
                },
            };

            var ben = new Character
            {
                Name = new Word("Dee", new() { Stress.Stressed }),
                PoeticNames = new() {
                    new Word("stabs", new() { Stress.Stressed }),
                },
                Nouns = new() {
                    new Word("wizard", new() { Stress.Stressed, Stress.Unstressed }),
                },
                Adjectives = new() {
                    new Word("magic", new() { Stress.Stressed, Stress.Unstressed }),
                },
                OffensivePossessions = new() {
                    new Word("knife", new() { Stress.Stressed }),
                    new Word("healing aura hex", new() { Stress.Stressed, Stress.Unstressed, Stress.Stressed, Stress.Unstressed, Stress.Stressed }),
                },
                OffensivePossessionsPlural = new() {
                    new Word("spells", new() { Stress.Stressed }),
                },
                InfinitiveVerbs = new() {
                },
                PreteriteTransitiveVerbs = new() {
                    new Word("cast", new() { Stress.Stressed }),
                },
            };

            var ang = new Character
            {
                Name = new Word("Bert", new() { Stress.Stressed }),
                PoeticNames = new() {
                    new Word("farming", new() { Stress.Stressed, Stress.Unstressed }),
                },
                Nouns = new() {
                    new Word("farmhand", new() { Stress.Stressed, Stress.Unstressed }),
                },
                OffensivePossessions = new() {
                    new Word("pitchfork", new() { Stress.Stressed, Stress.Unstressed }),
                },
                OffensivePossessionsPlural = new() {
                    new Word("arrows", new() { Stress.Stressed, Stress.Unstressed }),
                },
                InfinitiveVerbs = new() {
                },
            };

            var snake = new Character
            {
                Name = new Word("snake", new() { Stress.Stressed }),
                PoeticNames = new() {
                    new Word("serpent", new() { Stress.Stressed, Stress.Unstressed }),
                    new Word("adder", new() { Stress.Stressed, Stress.Unstressed }),
                },
                Nouns = new() {
                    new Word("serpent", new() { Stress.Stressed, Stress.Unstressed }),
                    new Word("adder", new() { Stress.Stressed, Stress.Unstressed }),
                },
                OffensivePossessions = new() {
                    new Word("fangs", new() { Stress.Stressed }),
                    new Word("venom", new() { Stress.Stressed, Stress.Unstressed }),
                },
                OffensivePossessionsPlural = new() {
                    new Word("fangs", new() { Stress.Stressed }),
                    new Word("venom", new() { Stress.Stressed, Stress.Unstressed }),
                },
                InfinitiveVerbs = new() {
                },
                PreteriteVerbs = new() {
                    new Word("hissed", new() { Stress.Stressed }),
                },
                PreteriteTransitiveVerbs = new() {
                    new Word("leapt", new() { Stress.Stressed }),
                },
            };

            var troll = new Character
            {
                Name = new Word("minotaur", new() { Stress.Stressed }),
                PoeticNames = new() {
                },
                Nouns = new() {
                    new Word("troll", new() { Stress.Stressed }),
                    new Word("giant", new() { Stress.Stressed, Stress.Unstressed }),
                },
                OffensivePossessions = new() {
                    new Word("club", new() { Stress.Stressed }),
                },
                OffensivePossessionsPlural = new() {
                },
                InfinitiveVerbs = new() {
                },
                PreteriteVerbs = new() {
                    new Word("rose", new() { Stress.Stressed }),
                },
            };

            Console.WriteLine(SongBase.GenerateLyrics(
                thorg,
                ben,
                ang,
                snake,
                troll,
                new Word("nest", new() { Stress.Stressed }),
                new Word("clearing", new() { Stress.Stressed, Stress.Unstressed })
            ));
        }
    }
}
