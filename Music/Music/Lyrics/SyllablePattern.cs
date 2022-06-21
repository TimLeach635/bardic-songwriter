using System;
using System.Collections.Generic;

namespace Music.Lyrics
{
    public class SyllablePattern
    {
        public IList<Stress> Syllables { get; }

        public SyllablePattern(IList<Stress> syllables)
        {
            Syllables = syllables;
        }

        public SyllablePattern(string syllables)
        {
            Syllables = new List<Stress>();

            foreach (char character in syllables)
            {
                switch (character)
                {
                    case 'S':
                        Syllables.Add(Stress.Stressed);
                        break;
                    case 's':
                        Syllables.Add(Stress.Unstressed);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(
                            "syllables",
                            syllables,
                            "All characters in the string \"syllables\" must be either a lowercase or uppercase \"S\""
                        );
                }
            }
        }
    }
}
