using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nwd.FrontOffice.Model;
using System.Web;

namespace Nwd.FrontOffice.Impl
{
    public class PlaylistManagement : IPlaylistManagement
    {
        public void AddNewPlaylistToCurrentUser( string playlistName )
        {
            if( String.IsNullOrWhiteSpace( playlistName ) ) throw new ArgumentNullException();

            var httpContext = HttpContext.Current;
            if( !httpContext.User.Identity.IsAuthenticated )
            {
                throw new UnauthorizedAccessException( "You must be authenticated in order to create a new playlist" );
            }
            using( var ctx = new NwdFrontOfficeContext() )
            {
                var user = ctx.Users.SingleOrDefault( u => u.UserName == httpContext.User.Identity.Name );
                if( user == null )
                {
                    user = ctx.Users.Add( new User
                    {
                        UserName = httpContext.User.Identity.Name
                    } );
                }
                user.Playlists.Add( new Playlist
                {
                    Title = playlistName
                } );

                ctx.SaveChanges();
            }
        }

        public void AddTrackToPlaylist( string playlistName, string songName, string songUrl )
        {
            if( String.IsNullOrWhiteSpace( playlistName ) ) throw new ArgumentNullException();
            if( String.IsNullOrWhiteSpace( songName ) ) throw new ArgumentNullException();
            if( String.IsNullOrWhiteSpace( songUrl ) ) throw new ArgumentNullException();

            var httpContext = HttpContext.Current;
            using( var ctx = new NwdFrontOfficeContext() )
            {
                var user = ctx.Users.SingleOrDefault( u => u.UserName == httpContext.User.Identity.Name );
                if( user == null )
                {
                    throw new ApplicationException( "user does not exists" );
                }

                var playList = user.Playlists.SingleOrDefault( p => p.Title == playlistName );
                if( playList == null )
                {
                    throw new ApplicationException( "The playlist does not exists. Please valid this before calling this method." );
                }
                playList.Tracks.Add( new PlaylistTrack
                {
                    SongName = songName,
                    SongUrl = songUrl
                } );

                ctx.SaveChanges();
            }
        }
    }
}
