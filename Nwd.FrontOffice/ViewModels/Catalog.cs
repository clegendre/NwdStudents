using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nwd.FrontOffice.ViewModels
{
    public class Catalog
    {
        public int NumberOfAlbum { get; set; }

        public IEnumerable<AlbumThumbnailViewModel> Albums { get; set; }
    }
}
