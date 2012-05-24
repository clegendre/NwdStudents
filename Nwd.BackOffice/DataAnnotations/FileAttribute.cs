using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Nwd.BackOffice.DataAnnotations
{
    public class FileAttribute : DataTypeAttribute, IMetadataAware
    {
        private readonly string[] _extensionsAccepted;

        public FileAttribute( params string[] extensionsAccepted )
            : base( "File" )
        {
            _extensionsAccepted = extensionsAccepted;
        }

        public void OnMetadataCreated( ModelMetadata metadata )
        {
            metadata.AdditionalValues.Add( "Extensions", _extensionsAccepted );
        }
    }
}
