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
                    new() { Stress.Unstressed, Stress.Unstressed },
                },
            }
        };
        List<Stress> testPattern = new() { Stress.Unstressed, Stress.Unstressed };

        bool result = pattern.IsSatisfiedBy(testPattern);

        Assert.That(result, Is.True);
    }

    [Test]
    public void PatternMatcher_CanChooseBetweenAlternatives()
    {
        Pattern pattern = new Pattern
        {
            Syllables = new()
            {
                new()
                {
                    new() { Stress.Unstressed },
                    new() { Stress.Stressed },
                },
                new()
                {
                    new() { Stress.Unstressed },
                    new() { Stress.Stressed },
                },
                new()
                {
                    new() { Stress.Unstressed },
                    new() { Stress.Stressed },
                },
                new()
                {
                    new() { Stress.Unstressed },
                    new() { Stress.Stressed },
                },
                new()
                {
                    new() { Stress.Unstressed },
                    new() { Stress.Stressed },
                },
            }
        };
        List<Stress> testPattern = new() { Stress.Stressed, Stress.Unstressed, Stress.Unstressed, Stress.Stressed, Stress.Unstressed };

        bool result = pattern.IsSatisfiedBy(testPattern);

        Assert.That(result, Is.True);
    }

    [Test]
    public void PatternMatcher_MatchesRealisticTestCase()
    {
        Pattern pattern = new Pattern
        {
            Syllables = new()
            {
                new()
                {
                    new() { Stress.Unstressed, Stress.Stressed },
                    new() { Stress.Stressed },
                },
                new()
                {
                    new() { Stress.Unstressed, Stress.Unstressed, Stress.Stressed },
                    new() { Stress.Unstressed, Stress.Stressed },
                    new() { Stress.Stressed },
                },
                new()
                {
                    new() { Stress.Unstressed, Stress.Unstressed, Stress.Stressed },
                    new() { Stress.Unstressed, Stress.Stressed },
                    new() { Stress.Stressed },
                },
                new()
                {
                    new() { Stress.Unstressed, Stress.Unstressed, Stress.Stressed },
                    new() { Stress.Unstressed, Stress.Stressed },
                    new() { Stress.Stressed },
                },
                new()
                {
                    new() { Stress.Unstressed, Stress.Unstressed, Stress.Stressed },
                    new() { Stress.Unstressed, Stress.Stressed },
                    new() { Stress.Stressed },
                },
                new()
                {
                    new() { Stress.Unstressed, Stress.Unstressed, Stress.Stressed },
                    new() { Stress.Unstressed, Stress.Stressed },
                    new() { Stress.Stressed },
                },
                new()
                {
                    new() { Stress.Unstressed, Stress.Unstressed, Stress.Stressed },
                    new() { Stress.Unstressed, Stress.Stressed },
                    new() { Stress.Stressed },
                },
            }
        };
        List<Stress> testPattern = new()
        {
            Stress.Unstressed, Stress.Stressed, Stress.Unstressed, Stress.Stressed,
            Stress.Unstressed, Stress.Stressed, Stress.Unstressed, Stress.Unstressed, Stress.Stressed,
            Stress.Unstressed, Stress.Stressed, Stress.Unstressed, Stress.Stressed,
            Stress.Unstressed, Stress.Unstressed, Stress.Stressed,
        };

        bool result = pattern.IsSatisfiedBy(testPattern);

        Assert.That(result, Is.True);
    }
}