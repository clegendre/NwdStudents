using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace Nwd.BackOffice.Model
{
    public class Album
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }

        public virtual Artist Artist { get; set; }

        public string CoverImagePath { get; set; }
        
        [NotMapped]
        public HttpPostedFileBase CoverFile { get; set; }
    }
}
