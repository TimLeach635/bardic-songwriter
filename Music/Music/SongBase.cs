using System.Text;
using System.Linq;
using Music.Lyrics;
using Music.Story;

namespace Music
{
    public class SongBase
    {
        public static string GenerateLyrics(
            Character protagonist,
            Character ally1,
            Character ally2,
            Character smallEnemy,
            Character bigEnemy,
            Word location,
            Word fightArena
        )
        {
            var builder = new StringBuilder();

            // Verse 1
            builder.Append(protagonist.PoeticNames.Where(word => word.Foot == Foot.SingleSyllable).First().Spelling);
            builder.Append(", and ");
            builder.Append(ally1.PoeticNames.Where(word => word.Foot == Foot.SingleSyllable).First().Spelling);
            builder.Append(", and ");
            builder.Append(ally2.PoeticNames.Where(word => word.Foot == Foot.Trochee).First().Spelling);

            builder.Append('\n');

            builder.Append($"\tset out amongst the {location},");

            builder.Append('\n');

            builder.Append($"With {protagonist.Name.Spelling}, a ");
            builder.Append(protagonist.Nouns.Where(word => word.Foot == Foot.SingleSyllable).First().Spelling);
            builder.Append(" of ");
            builder.Append(protagonist.OffensivePossessions.First().Spelling);
            builder.Append(" and ");
            builder.Append(protagonist.OffensivePossessions.Where(word => word.Foot == Foot.SingleSyllable).First().Spelling);

            builder.Append('\n');

            builder.Append("\tthe enemy ready to ");
            builder.Append(protagonist.InfinitiveVerbs.Where(word => word.Foot == Foot.SingleSyllable).First().Spelling);
            builder.Append('.');

            return builder.ToString();
        }
    }
}
