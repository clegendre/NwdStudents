using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nwd.FrontOffice.ViewModels;

namespace Nwd.FrontOffice
{
    public interface IMusicReader
    {
        MiniPlayer GetMiniPlayerFor(int idAlbum, int trackNumber);

        Catalog GetCatalog();

        AlbumViewModel GetAlbum( int idAlbum );
    }
}
