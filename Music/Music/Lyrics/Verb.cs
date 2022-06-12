namespace Music.Lyrics
{
    public class Verb
    {
        // Base form: "eat", "attack", "be", "have"
        public Word Base { get; set; }

        // Present tense: "eat", "attack", "be", "have"
        public Conjugation Present { get; set; }

        // Simple past tense: "ate", "attacked", "was", "had"
        public Conjugation SimplePast { get; set; }

        // Past participle (same as the simple past tense for regular verbs): "eaten", "attacked", "been", "had"
        public Word PastParticiple { get; set; }

        // Present participle: "eating", "attacking", "being", "having"
        public Word PresentParticiple { get; set; }
    }
}
