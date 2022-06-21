using System;
using System.Collections.Generic;

namespace Music.Lyrics
{
    public class Word
    {
        public string Spelling { get; set; }
        public SyllablePattern Syllables { get; set; }
        public Foot Foot
        {
            get
            {
                switch (Syllables.Syllables.Count)
                {
                    case 1:
                        return Foot.SingleSyllable;
                    case 2:
                        if (Syllables.Syllables[0] == Stress.Stressed)
                            return Foot.Trochee;
                        return Foot.Iamb;
                    case 3:
                        if (Syllables.Syllables[0] == Stress.Stressed)
                            return Foot.Dactyl;
                        if (Syllables.Syllables[1] == Stress.Stressed)
                            return Foot.Amphibrach;
                        return Foot.Anapest;
                    case 4:
                        if (Syllables.Syllables[0] == Stress.Stressed)
                            return Foot.PrimusPaeon;
                        if (Syllables.Syllables[1] == Stress.Stressed)
                            return Foot.SecundusPaeon;
                        if (Syllables.Syllables[2] == Stress.Stressed)
                            return Foot.TertiusPaeon;
                        return Foot.QuartusPaeon;
                    default:
                        return Foot.MoreThanFourSyllables;
                }
            }
        }

        public Word(string spelling, SyllablePattern syllables)
        {
            Spelling = spelling;
            Syllables = syllables;
        }

        public Word(string spelling, IList<Stress> syllables)
        {
            Spelling = spelling;
            Syllables = new(syllables);
        }

        public Word(string spelling, string syllables)
        {
            Spelling = spelling;
            Syllables = new(syllables);
        }

        public override string ToString()
        {
            return Spelling;
        }
    }
}
