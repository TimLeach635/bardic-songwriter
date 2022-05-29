using System.Collections.Generic;
using System.Linq;
using Music.Lyrics;

namespace Music.Song
{
    public class Pattern {
        // A "pattern", here, is a list of lists of lists of syllables - each
        // list represents a mutually exclusive set of syllable patterns
        public List<List<List<Stress>>> Syllables { get; set; }

        public static bool AreTheSame(IEnumerable<Stress> list1, IEnumerable<Stress> list2)
        {
            return list1.Join(list2, a => a, a => a, (a, b) => a == b).All(a => a);
        }

        public bool IsSatisfiedBy(List<Stress> testSyllables)
        {
            /*
            Pseudocode

            Work through the testSyllables array, matching its entries into the Pattern.

            1. Mark all testSyllables as "unmatched", and all Pattern groups as "unsatisfied"
            2. While there are "unmatched" testSyllables:
                a. Order the earliest "unsatisfied" Pattern group by length, with the longest first
                b. For each syllable list (length N) in the earliest "unsatisfied" Pattern group:
                    i. If the next N "unmatched" testSyllables match this syllable list:
                        A. Mark the next N "unmatched" testSyllables as "matched"
                        B. Mark this syllable list as "satisfied"
                c. If no testSyllables were marked as "matched" during the above "for" loop:
                    i. If there are no "matched" Pattern groups:
                        A. Return FALSE. The test pattern does not satisfy this pattern.
                    ii. Identify the syllable list (length N) in the latest "satisfied" Pattern group
                        which was matched against the test pattern, and remove it from consideration in future steps
                    iii. Mark the latest "satisfied" Pattern group as "unsatisfied"
                    iv. Mark the latest N "matched" testSyllables as "unmatched"
                    v. Go back to step 2.b.
            3. If there remain "unsatisfied" Pattern groups:
                a. Return FALSE.
            4. Return TRUE.

            */

            // 1.
            int nMatchedTestSyllables = 0;
            int nSatisfiedPatternGroups = 0;
            List<List<List<Stress>>> attemptedPatternLists = Syllables
                .Select<List<List<Stress>>, List<List<Stress>>>(_ => new())
                .ToList();

            // 2.
            while (nMatchedTestSyllables < testSyllables.Count)
            {
                // 2.a.
                List<List<Stress>> nextUnsatisfiedGroup = Syllables[nSatisfiedPatternGroups]
                    .OrderBy<List<Stress>, int>(list => list.Count)
                    // (2.c.ii.)
                    .Where(syllableList => !attemptedPatternLists[nSatisfiedPatternGroups].Any(attemptedList => AreTheSame(attemptedList, syllableList)))
                    .ToList();

                // 2.b.
                bool didMatch = false;

                foreach (List<Stress> syllableList in nextUnsatisfiedGroup)
                {
                    // 2.b.i.
                    if (AreTheSame(syllableList, testSyllables.Skip(nMatchedTestSyllables).Take(syllableList.Count)))
                    {
                        // 2.b.i.A.
                        nMatchedTestSyllables += syllableList.Count;

                        // 2.b.i.B.
                        attemptedPatternLists[nSatisfiedPatternGroups].Add(syllableList);
                        nSatisfiedPatternGroups++;


                        didMatch = true;
                    }
                }

                // 2.c.
                if (!didMatch)
                {
                    // 2.c.i.
                    if (nSatisfiedPatternGroups == 0)
                    {
                        // 2.c.i.A.
                        return false;
                    }

                    // 2.c.ii,iii
                    nSatisfiedPatternGroups--;
                    List<Stress> lastSatisfiedSyllableList = attemptedPatternLists[nSatisfiedPatternGroups].Last();
                    
                    // 2.c.iv.
                    nMatchedTestSyllables -= lastSatisfiedSyllableList.Count();
                }
            }

            // 3.
            if (nSatisfiedPatternGroups < Syllables.Count)
            {
                // 3.a.
                return false;
            }

            return true;
        }
    }
}
