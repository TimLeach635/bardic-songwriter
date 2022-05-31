using System.Collections.Generic;
using System.Linq;
using Music.Lyrics;
using NLog;

namespace Music.Song
{
    public class Pattern {
        private readonly NLog.Logger Logger;

        // A "pattern", here, is a list of lists of lists of syllables - each
        // list represents a mutually exclusive set of syllable patterns
        public List<List<List<Stress>>> Syllables { get; set; }

        public Pattern()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = @"C:\coding\bardic-songwriter\log.log" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
                        
            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
                        
            // Apply config           
            NLog.LogManager.Configuration = config;

            Logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public static bool AreTheSame(IEnumerable<Stress> list1, IEnumerable<Stress> list2)
        {
            return list1.Join(list2, a => a, a => a, (a, b) => a == b).All(a => a);
        }

        public static string Display(List<Stress> list)
        {
            return $"Syllables: [{string.Join(", ", list.Select(s => s == Stress.Stressed ? "S" : "s"))}]";
        }

        public static string Display(List<List<Stress>> list)
        {
            return $"Syllable groups:\n[\n    {string.Join(",\n    ", list.Select(sl => Display(sl)))}\n]";
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
            Logger.Debug($"Testing \"{Display(testSyllables)}\"");

            // 1.
            Logger.Debug("1. Mark all testSyllables as \"unmatched\", and all Pattern groups as \"unsatisfied\"");
            int nMatchedTestSyllables = 0;
            int nSatisfiedPatternGroups = 0;
            List<List<List<Stress>>> attemptedPatternLists = Syllables
                .Select<List<List<Stress>>, List<List<Stress>>>(_ => new())
                .ToList();
            Logger.Debug($"> nMatchedTestSyllables = {nMatchedTestSyllables}");
            Logger.Debug($"> nSatisfiedPatternGroups = {nSatisfiedPatternGroups}");
            Logger.Debug($"> attemptedPatternLists = {attemptedPatternLists}");

            // 2.
            Logger.Debug("2. While there are \"unmatched\" testSyllables:");
            while (nMatchedTestSyllables < testSyllables.Count)
            {
                Logger.Debug("> Beginning test loop (there are still unmatched testSyllables)");
                Logger.Debug($"> nMatchedTestSyllables ({nMatchedTestSyllables}) < testSyllables.Count ({testSyllables.Count})");
                // 2.a.
                Logger.Debug("2.a. Order the earliest \"unsatisfied\" Pattern group by length, with the longest first");
                List<List<Stress>> nextUnsatisfiedGroup = Syllables[nSatisfiedPatternGroups]
                    .OrderBy<List<Stress>, int>(list => list.Count)
                    // (2.c.ii.)
                    .Where(syllableList => !attemptedPatternLists[nSatisfiedPatternGroups].Any(attemptedList => AreTheSame(attemptedList, syllableList)))
                    .ToList();
                Logger.Debug($"> nextUnsatisfiedGroup = {Display(nextUnsatisfiedGroup)}");
                Logger.Debug($"> nextUnsatisfiedGroup.Count = {nextUnsatisfiedGroup.Count}");

                // 2.b.
                bool didMatch = false;

                Logger.Debug("2.b. For each syllable list (length N) in the earliest \"unsatisfied\" Pattern group:");
                Logger.Debug($"> Looping through nextUnsatisfiedGroup (length {nextUnsatisfiedGroup.Count}):");
                foreach (List<Stress> syllableList in nextUnsatisfiedGroup)
                {
                    Logger.Debug($"> syllableList = {Display(syllableList)}");
                    // 2.b.i.
                    Logger.Debug("2.b.i. If the next N \"unmatched\" testSyllables match this syllable list:");
                    if (AreTheSame(syllableList, testSyllables.Skip(nMatchedTestSyllables).Take(syllableList.Count)))
                    {
                        Logger.Debug("> syllableList matches next testSyllables!");
                        // 2.b.i.A.
                        Logger.Debug("2.b.i.A. Mark the next N \"unmatched\" testSyllables as \"matched\"");
                        Logger.Debug($"> Adding length ({syllableList.Count}) of this syllableList ({Display(syllableList)}) to nMatchedTestSyllables ({nMatchedTestSyllables})");
                        nMatchedTestSyllables += syllableList.Count;
                        Logger.Debug($"> nMatchedTestSyllables now = {nMatchedTestSyllables}");

                        // 2.b.i.B.
                        Logger.Debug("2.b.i.B. Mark this syllable list as \"satisfied\"");
                        Logger.Debug($"> Adding syllableList ({Display(syllableList)}) to attemptedPatternLists[{nSatisfiedPatternGroups}]");
                        attemptedPatternLists[nSatisfiedPatternGroups].Add(syllableList);
                        Logger.Debug($"> Incrementing nSatisfiedPatternGroups (currently {nSatisfiedPatternGroups}) by 1");
                        nSatisfiedPatternGroups++;

                        didMatch = true;

                        break;
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
