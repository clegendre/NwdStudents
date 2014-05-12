using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Moq;
using NUnit.Framework;
using Nwd.BackOffice.Impl;
using Nwd.BackOffice.Model;

namespace Nwd.Tests
{
    [TestFixture]
    public class AlbumRepositoryTests
    {
        [Test]
        public void Create_Album_With_No_Tracks()
        {
            AlbumRepository repo = new AlbumRepository();
            HttpServerUtilityBase server =  Mock.Of<HttpServerUtilityBase>();

            Album album = repo.CreateAlbum( new BackOffice.Model.Album
            {
                Duration = TimeSpan.FromHours( 2 ),
                Title = RandomName(),
                Artist = new BackOffice.Model.Artist { Name = RandomName() },
                ReleaseDate = DateTime.UtcNow,
                Type = "Pop-Rock"
            }, server );

            Assert.That( album.Id, Is.GreaterThan( 0 ) );
        }

        [Test]
        public void Create_Album_With_Tracks()
        {
            AlbumRepository repo = new AlbumRepository();
            HttpServerUtilityBase server =  Mock.Of<HttpServerUtilityBase>();

            var mock = new Mock<HttpPostedFileBase>();

            Assert.Throws<ApplicationException>( () =>
                {
                    CreateAlbumWithMockFile( repo, server, mock );
                }, "The file must be an .mp3 file" );

            mock.SetupGet( x => x.FileName ).Returns( RandomName() + ".mp3" );

           Album album = CreateAlbumWithMockFile( repo, server, mock );
           Assert.That( album.Id, Is.GreaterThan( 0 ) );
        }

        private Album CreateAlbumWithMockFile( AlbumRepository repo, HttpServerUtilityBase server, Mock<HttpPostedFileBase> mock )
        {
            Album album = repo.CreateAlbum( new BackOffice.Model.Album
            {
                Duration = TimeSpan.FromHours( 2 ),
                Title = RandomName(),
                Artist = new BackOffice.Model.Artist { Name = RandomName() },
                ReleaseDate = DateTime.UtcNow,
                Type = "Hip-Hop US",
                Tracks = new List<Track>
                            {
                                new Track
                                { 
                                    Number = 1,
                                    Duration = TimeSpan.FromMinutes(4),
                                    File = mock.Object,
                                    Song = new Song
                                    {
                                        Name = RandomName(),
                                        Composed = new DateTime(2010,1,12)
                                    }
                                }
                            }
            }, server );

            return album;
        }

        [Test]
        public void Edit_Album()
        {
            AlbumRepository repo = new AlbumRepository();
            HttpServerUtilityBase server =  Mock.Of<HttpServerUtilityBase>();

            Album album = repo.CreateAlbum( new BackOffice.Model.Album
            {
                Duration = TimeSpan.FromHours( 2 ),
                Title = RandomName(),
                Artist = new BackOffice.Model.Artist { Name = RandomName() },
                ReleaseDate = DateTime.UtcNow,
                Type = "Pop-Rock"
            }, server );

            Assert.That( album.Id, Is.GreaterThan( 0 ) );

            album.Title = "New Title";
            album = repo.EditAlbum( server, album );

            Assert.That( album.Title == "New Title" );
        }

        private string RandomName()
        {
            return Path.GetFileNameWithoutExtension( Path.GetRandomFileName() );
        }
    }
}
