using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Nwd.BackOffice.Model
{
    public class NwdBackOfficeContext : DbContext
    {
        public NwdBackOfficeContext()
            : base("NwdMusik")
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Track> Tracks { get; set; }
    }
}
