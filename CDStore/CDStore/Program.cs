using System;
using System.Linq;

namespace CDStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CDStoreDbContext();
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Write("\n\nEnter 1 to add an Artist \n2 to List Artists \n3 Find artist \n4 to Find CD \n9 to Quit : ");
                char key = Console.ReadLine()[0];
                switch (key)
                {
                    case '1':
                        Console.WriteLine();
                        AddArtist(context);
                        break;
                    case '2':
                        Console.WriteLine();
                        ListArtists(context);
                        break;
                    case '3':
                        Console.WriteLine();
                        FindArtist(context);
                        break;
                    case '4':
                        Console.WriteLine();
                        FindCD(context);
                        break;
                    case '9':
                        keepGoing = false;
                        break;
                }
            }
        }

        private static void FindArtist(CDStoreDbContext context)
        {
            Console.WriteLine("Enter Artist's name: ");
            var name = Console.ReadLine();
            var artist = context.Artists.FirstOrDefault(a => a.Name.Contains(name));
            Console.WriteLine("Artist: " + artist.Name);
            foreach (Song s in artist.Songs)
            {
                Console.WriteLine(s.Title + "\t" + s.MusicType);
            }

        }

        private static void ListArtists(CDStoreDbContext context)
        {
            foreach (Artist a in context.Artists)
            {
                Console.WriteLine(a.Name + " " + a.ArtistId);
            }
            Console.WriteLine();
        }

        private static void AddArtist(CDStoreDbContext context)
        {
            Console.Write("Enter name of new Artist: ");
            string name = Console.ReadLine();
            Artist a = new Artist() { Name = name };
            context.Artists.Add(a);
            context.SaveChanges();
            Console.Write("Would you like to add a song for the Artist y/n: ");
            char answer = Console.ReadKey().KeyChar;
            while (answer == 'y')
            {
                Console.WriteLine();
                Console.Write("Enter Song Made by Artist: ");
                string title = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Enter Music type: ");
                string type = Console.ReadLine();
                Song b = new Song() { Title = title, MusicType = type, Artist = a};
                Console.WriteLine("Saving ...");
                Console.WriteLine();
                context.Songs.Add(b);
                context.SaveChanges();
                Console.Write("Would you like to add another song y/n: ");
                answer = Console.ReadKey().KeyChar;
            }
        }

        private static void FindCD(CDStoreDbContext context)
        {
            Console.WriteLine("Enter Title of CD: ");
            var title = Console.ReadLine();
            var cd = context.CDs.FirstOrDefault(a => a.Title.Contains(title));
            Console.WriteLine("CD: " + cd.Title);
            foreach (Song s in cd.Songs)
            {
                Console.WriteLine(s.Artist.Name + "\t" + s.Title + "\t"  + s.MusicType);
            }

        }


    }
}
