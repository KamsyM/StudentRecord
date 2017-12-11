using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace CDStore
{
    public class CDStoreDbContext : DbContext
    {
        public CDStoreDbContext() : base("myConnectionString")
        {
            Database.SetInitializer(new CustomInitializer());
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        
    }

}
