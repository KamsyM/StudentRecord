using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CDStore
{
    public class CustomInitializer : DropCreateDatabaseAlways<CDStoreDbContext>
    {
        protected override void Seed(CDStoreDbContext context)
        {
            var fb = CreateArtist(context, "Fred Bates");
            var mo = CreateArtist(context, "Maria Okello");
            var bh = CreateArtist(context, "Bobby Harris");
            var jm = CreateArtist(context, "Jo Morris");
            var jj = CreateArtist(context, "JJ");
            var rap = CreateArtist(context, "Rapport");

            CreateSong(context, "Waterfall", jj, "Americana");
            CreateSong(context, "Shake it", fb, "Heavy Metal");
            CreateSong(context, "Come Away", bh, "Americana");
            CreateSong(context, "Volcano", mo, "Art Pop");
            CreateSong(context, "Complicated Game", jj, "Americana");
            CreateSong(context, "Ghost Town", fb, "Heavy Metal");
            CreateSong(context, "Gentle Waves", mo, "Art Pop");
            CreateSong(context, "Right Here", mo, "Art Pop");
            CreateSong(context, "Clouds", jm, "Art Pop");
            CreateSong(context, "Sheet Steel", rap, "Heavy Metal");
            CreateSong(context, "Here with you", bh, "Art Pop");
        }

        private Artist CreateArtist(CDStoreDbContext context, string name)
        {
            var a = new Artist() { Name = name };
            context.Artists.Add(a);
            context.SaveChanges();
            return a;
        }

        private Song CreateSong(CDStoreDbContext context, string title, Artist artist, string type)
        {
            var a = new Song() { Title = title, MusicType = type, Artist = artist };
            context.Songs.Add(a);
            context.SaveChanges();
            return a;
        }
    }
}