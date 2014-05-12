using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nwd.BackOffice.Model
{
    public partial class Track
    {
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
    }
}
