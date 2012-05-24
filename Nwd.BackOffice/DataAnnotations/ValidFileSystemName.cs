using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Nwd.BackOffice.DataAnnotations
{
    public class ValidFileSystemNameAttribute : ValidationAttribute
    {
        public override bool IsValid( object value )
        {
            if( value is string )
            {
                return !(from c in value.ToString().ToCharArray()
                        let invalidPathChars = System.IO.Path.GetInvalidPathChars()
                        where invalidPathChars.Contains( c )
                        select c).Any();
            }
            return false;
        }
    }
}
