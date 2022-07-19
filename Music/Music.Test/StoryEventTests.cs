using System.Collections.Generic;
using Music.Lyrics;
using Music.Story;
using NUnit.Framework;

namespace Music.Test;

public class StoryEventTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("the heroes", "went to", "the forest", "The heroes went to the forest")]
    [TestCase("the snake", "bit", "Thorg", "The snake bit Thorg")]
    [TestCase("Ben", "healed", "Thorg", "Ben healed Thorg")]
    [TestCase("Thorg", "attacked", "the troll", "Thorg attacked the troll")]
    public void StoryEventWithSubjectObjectAndVerb_GeneratesGrammaticalLyrics(string subjectEntityName, string thirdPersonSimplePastVerb, string objectEntityName, string expectedLyrics)
    {
        StoryEntity subjectEntity = new StoryEntity(subjectEntityName);
        StoryEntity objectEntity = new StoryEntity(objectEntityName);
        ThirdPersonSimplePastVerb verb = new ThirdPersonSimplePastVerb(thirdPersonSimplePastVerb);

        StoryEvent storyEvent = new StoryEvent(subjectEntity, verb, objectEntity);

        Assert.That(storyEvent.GenerateLyrics(), Is.EqualTo(expectedLyrics));
    }
}