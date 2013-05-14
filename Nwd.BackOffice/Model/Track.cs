using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nwd.BackOffice.Model
{
    public class Track
    {
        [Key]
        [Column( Order = 0 )]
        public int? AlbumId { get; set; }

        [Key]
        [Column( Order = 1 )]
        public int Number { get; set; }

        public virtual Song Song { get; set; }

        public TimeSpan Duration { get; set; }

        [ForeignKey( "AlbumId" )]
        public virtual Album Album { get; set; }

        public string FileRelativePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase File { get; set; }
    }
}
