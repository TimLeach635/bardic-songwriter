using System;
using System.Collections;
using System.Collections.Generic;

namespace Music.Lyrics
{
    public class SyllablePattern : IList<Stress>
    {
        public IList<Stress> Syllables { get; }
        public int Count => Syllables.Count;

        public bool IsReadOnly => Syllables.IsReadOnly;

        public SyllablePattern(IList<Stress> syllables)
        {
            Syllables = syllables;
        }

        public SyllablePattern(string syllables)
        {
            Syllables = new List<Stress>();

            foreach (char character in syllables)
            {
                switch (character)
                {
                    case 'S':
                        Syllables.Add(Stress.Stressed);
                        break;
                    case 's':
                        Syllables.Add(Stress.Unstressed);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(
                            "syllables",
                            syllables,
                            "All characters in the string \"syllables\" must be either a lowercase or uppercase \"S\""
                        );
                }
            }
        }

        public Stress this[int index]
        {
            get
            {
                return Syllables[index];
            }
            set
            {
                Syllables[index] = value;
            }
        }

        public int IndexOf(Stress stress) => Syllables.IndexOf(stress);
        public void Insert(int index, Stress stress) => Syllables.Insert(index, stress);
        public void RemoveAt(int index) => Syllables.RemoveAt(index);
        public void Add(Stress item) => Syllables.Add(item);
        public void Clear() => Syllables.Clear();
        public bool Contains(Stress item) => Syllables.Contains(item);
        public void CopyTo(Stress[] array, int arrayIndex) => Syllables.CopyTo(array, arrayIndex);
        public bool Remove(Stress item) => Syllables.Remove(item);
        public IEnumerator<Stress> GetEnumerator() => Syllables.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Syllables).GetEnumerator();
    }
}
