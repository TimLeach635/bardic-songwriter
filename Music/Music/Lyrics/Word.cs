using System;
using System.Collections.Generic;

namespace Music.Lyrics
{
    public class Word
    {
        public string Spelling { get; set; }
        public List<Stress> Syllables { get; set; }
        public Foot Foot
        {
            get
            {
                switch (Syllables.Count)
                {
                    case 1:
                        return Foot.SingleSyllable;
                    case 2:
                        if (Syllables[0] == Stress.Stressed)
                            return Foot.Trochee;
                        return Foot.Iamb;
                    case 3:
                        if (Syllables[0] == Stress.Stressed)
                            return Foot.Dactyl;
                        if (Syllables[1] == Stress.Stressed)
                            return Foot.Amphibrach;
                        return Foot.Anapest;
                    case 4:
                        if (Syllables[0] == Stress.Stressed)
                            return Foot.PrimusPaeon;
                        if (Syllables[1] == Stress.Stressed)
                            return Foot.SecundusPaeon;
                        if (Syllables[2] == Stress.Stressed)
                            return Foot.TertiusPaeon;
                        return Foot.QuartusPaeon;
                    default:
                        return Foot.MoreThanFourSyllables;
                }
            }
        }

        public Word(string spelling, List<Stress> syllables)
        {
            Spelling = spelling;
            Syllables = syllables;
        }

        public Word(string spelling, string syllables)
        {
            Spelling = spelling;
            Syllables = new();

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

        public override string ToString()
        {
            return Spelling;
        }
    }
}
