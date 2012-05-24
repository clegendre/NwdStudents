using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nwd.FrontOffice.Model
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
