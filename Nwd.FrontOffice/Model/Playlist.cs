using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Nwd.FrontOffice.Model
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<PlaylistTrack> Tracks { get; set; }
    }
}
