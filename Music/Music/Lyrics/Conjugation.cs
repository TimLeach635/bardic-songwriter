using System.Collections.Generic;

namespace Music.Lyrics
{
    public class Conjugation
    {
        private Dictionary<Person, Word> _forms = new Dictionary<Person, Word>();

        public Conjugation(Word i, Word you, Word heSheIt, Word we, Word youPlural, Word they)
        {
            _forms[Person.I] = i;
            _forms[Person.You] = you;
            _forms[Person.HeSheIt] = heSheIt;
            _forms[Person.We] = we;
            _forms[Person.YouPlural] = youPlural;
            _forms[Person.They] = they;
        }

        public Word GetConjugation(Person person)
        {
            return _forms[person];
        }
    }
}
