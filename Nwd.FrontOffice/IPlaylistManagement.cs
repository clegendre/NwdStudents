using System;
namespace Nwd.FrontOffice
{
    public interface IPlaylistManagement
    {
        void AddNewPlaylistToCurrentUser( string playlistName );
        void AddTrackToPlaylist( string playlistName, string songName, string songUrl );
    }
}
