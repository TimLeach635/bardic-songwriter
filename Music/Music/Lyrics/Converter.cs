using System.Collections.Generic;
using Music.Story;
using Music.XBar;

namespace Music.Lyrics
{
    public static class Converter
    {
        public static Phrase Convert(Event storyEvent)
        {
            Phrase verbObject = new Phrase(
                // head
                new Lexeme(new Word("PREPOSITION", ""), LexemeCategory.Preposition),
                null,
                new Phrase(
                    // head
                    new Lexeme(storyEvent.Object.Noun, LexemeCategory.Noun),
                    null,
                    null
                )
            );

            Phrase verbPhrase;
            
            if (storyEvent.Implement is not null)
            {
                Phrase instrumentalAdjunct = new Phrase(
                    // head
                    new Lexeme(new Word("with", "s"), LexemeCategory.Preposition),
                    null,
                    // complement
                    new Phrase(
                        // head
                        new Lexeme(storyEvent.Implement.Noun, LexemeCategory.Noun),
                        null,
                        null
                    )
                );

                verbPhrase = new Phrase(
                    // head
                    new Lexeme(storyEvent.Action.Verb.Base, LexemeCategory.Verb),
                    // specifier
                    null,
                    // complement
                    verbObject,
                    // adjuncts
                    new List<Phrase>()
                    {
                        instrumentalAdjunct
                    }
                );
            }
            else
            {
                verbPhrase = new Phrase(
                    // head
                    new Lexeme(storyEvent.Action.Verb.Base, LexemeCategory.Verb),
                    // specifier
                    null,
                    // complement
                    verbObject
                );
            }

            return new Phrase(
                // head
                new Lexeme(new Word("PAST", ""), LexemeCategory.Inflection),
                // specifier
                new Phrase(
                    // head
                    new Lexeme(storyEvent.Subject.Noun, LexemeCategory.Noun),
                    null,
                    null
                ),
                // complement
                verbPhrase
            );
        }
    }
}
