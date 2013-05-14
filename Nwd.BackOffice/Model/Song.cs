using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Nwd.BackOffice.Model
{
    public class Song
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public DateTime? Composed { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }

        public virtual ICollection<Artist> Features { get; set; }
    }
}
