using System.Collections.Generic;
using NUnit.Framework;
using Music.Lyrics;
using Music.Song;

namespace Music.Test;

public class PatternTest
{
    [SetUp]
    public void Setup()
    {
    }

    // [Test]
    // public void EmptyTestPattern_SatisfiesAllPatterns()
    // {
    //     Pattern pattern = new Pattern
    //     {
    //         Syllables = new()
    //         {
    //             new()
    //             {
    //                 new() { Stress.Unstressed },
    //             }
    //         }
    //     };
    //     List<Stress> testPattern = new();

    //     bool result = pattern.IsSatisfiedBy(testPattern);

    //     Assert.That(result, Is.True);
    // }

    [Test]
    public void SingleUnstressedSyllable_SatisfiesSingleUnstressedSyllablePattern()
    {
        Pattern pattern = new Pattern
        {
            Syllables = new()
            {
                new()
                {
                    new() { Stress.Unstressed },
                },
            }
        };
        List<Stress> testPattern = new() { Stress.Unstressed };

        bool result = pattern.IsSatisfiedBy(testPattern);

        Assert.That(result, Is.True);
    }

    [Test]
    public void TwoUnstressedSyllables_SatisfiesTwoOneUnstressedSyllableGroupsPattern()
    {
        Pattern pattern = new Pattern
        {
            Syllables = new()
            {
                new()
                {
                    new() { Stress.Unstressed },
                },
                new()
                {
                    new() { Stress.Unstressed },
                },
            }
        };
        List<Stress> testPattern = new() { Stress.Unstressed, Stress.Unstressed };

        bool result = pattern.IsSatisfiedBy(testPattern);

        Assert.That(result, Is.True);
    }

    [Test]
    public void TwoUnstressedSyllables_SatisfiesOneTwoUnstressedSyllablesGroupPattern()
    {
        Pattern pattern = new Pattern
        {
            Syllables = new()
            {
                new()
                {
                    new() { Stress.Unstressed },
                    new() { Stress.Unstressed },
                },
            }
        };
        List<Stress> testPattern = new() { Stress.Unstressed, Stress.Unstressed };

        bool result = pattern.IsSatisfiedBy(testPattern);

        Assert.That(result, Is.True);
    }
}