using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Nwd.FrontOffice.ViewModels
{
    public class MiniPlayer
    {
        public string SongFilePath { get; set; }

        public string SongUrl
        {
            get { return VirtualPathUtility.ToAppRelative( SongFilePath ); }
        }
    }
}
