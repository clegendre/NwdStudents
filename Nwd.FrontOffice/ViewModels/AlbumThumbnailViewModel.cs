using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nwd.FrontOffice.ViewModels
{
    public class AlbumThumbnailViewModel
    {
        public int AlbumId { get; set; }

        public string AlbumName { get; set; }

        public int TracksCount { get; set; }

        public string ArtistName { get; set; }

        public string CoverImageUrl { get; set; }
    }
}
