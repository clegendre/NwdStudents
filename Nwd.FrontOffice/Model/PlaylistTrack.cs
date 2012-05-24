using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Nwd.FrontOffice.Model
{
    public class PlaylistTrack
    {
        [Key]
        public int PlaylistTrackId { get; set; }

        public string SongUrl { get; set; }

        public string SongName { get; set; }
    }
}
