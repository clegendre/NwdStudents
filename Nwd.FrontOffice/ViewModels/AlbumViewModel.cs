using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nwd.FrontOffice.ViewModels;

namespace Nwd.FrontOffice
{
    public class AlbumViewModel
    {
        public string AlbumName { get; set; }

        public string CoverImageUrl { get; set; }

        public ICollection<TrackViewModel> Tracks {get; set;}
    }
}
