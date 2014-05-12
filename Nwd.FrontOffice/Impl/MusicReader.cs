using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Nwd.FrontOffice.ViewModels;
using Nwd.BackOffice.Model;

namespace Nwd.FrontOffice.Impl
{
    public class MusicReader : IMusicReader
    {
        public MiniPlayer GetMiniPlayerFor( int idAlbum, int trackNumber )
        {
            using( var ctx = new NwdMusikEntities() )
            {
                return
                    (
                        from a in ctx.Albums
                        let track = (from s in a.Tracks
                                     where s.AlbumId == a.Id && s.Number == trackNumber
                                     select s).FirstOrDefault()

                        where a.Id == idAlbum
                        select new MiniPlayer
                        {
                            SongFilePath = track.FileRelativePath
                        }
                    ).FirstOrDefault();

            }
        }

        public Catalog GetCatalog()
        {
            using( var ctx = new NwdMusikEntities() )
            {
                return new Catalog
                {
                    Albums = (from a in ctx.Albums
                              select new AlbumThumbnailViewModel
                              {
                                  AlbumId = a.Id,
                                  AlbumName = a.Title,
                                  ArtistName = a.Artist.Name,
                                  CoverImageUrl = a.CoverImagePath,
                                  TracksCount = a.Tracks.Count
                              }).ToArray(),
                    NumberOfAlbum = ctx.Albums.Count()
                };
            }
        }

        public AlbumViewModel GetAlbum( int idAlbum )
        {
            if( idAlbum == 0 )
            {
                throw new ArgumentException( "The id of the album must not be 0", "idAlbum" );
            }

            using( var ctx = new NwdMusikEntities() )
            {
                Album album = ctx.Albums.SingleOrDefault( a => a.Id == idAlbum );
                if( album != null )
                {
                    return new AlbumViewModel
                    {
                        AlbumName = album.Title,
                        CoverImageUrl = album.CoverImagePath,
                        Tracks = (from t in album.Tracks
                                  select new TrackViewModel
                                  {
                                      SongName = t.Song.Name,
                                      SongUrl = t.FileRelativePath,
                                      TrackNumber = t.Number
                                  }
                                ).ToArray()
                    };
                }
                return null;
            }
        }
    }
}
