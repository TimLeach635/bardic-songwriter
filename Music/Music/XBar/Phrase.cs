using Music.XBar.Categories;

namespace Music.XBar
{
    public class Phrase
    {
        public virtual Lexeme Head { get; }
        public Phrase Specifier { get; }
        public Phrase Complement { get; }
        public Phrase Adjunct { get; }

        public Phrase(Lexeme head, Phrase specifier, Phrase complement)
        {
            Head = head;
            Specifier = specifier;
            Complement = complement;
        }

        public Phrase(Lexeme head, Phrase specifier, Phrase complement, Phrase adjunct)
        {
            Head = head;
            Specifier = specifier;
            Complement = complement;
            Adjunct = adjunct;
        }
    }

    public class Phrase<T> : Phrase where T : Lexeme
    {
        public override T Head { get; }

        public Phrase(T head, Phrase specifier, Phrase complement) : base(head, specifier, complement) { }
        public Phrase(T head, Phrase specifier, Phrase complement, Phrase adjunct) : base(head, specifier, complement, adjunct) { }
    }
}
