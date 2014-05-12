using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;

namespace Nwd.BackOffice.Model
{
    public class RequiredIfAttribute : RequiredAttribute
    {
        private bool _hasFilePath = false;

        public string OtherPropertyName { get; set; }

        public RequiredIfAttribute( string otherPropertyName )
        {
            if( String.IsNullOrWhiteSpace( otherPropertyName ) ) throw new ArgumentNullException( "otherPropertyName" );

            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid( object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext )
        {
            ValidationResult valid = base.IsValid( value, validationContext );

            var property = validationContext.ObjectType.GetProperty( OtherPropertyName );
            if( property == null ) throw new ApplicationException( "The property with name " + OtherPropertyName + " is not found on the Model object" );

            string v = (string)property.GetValue( validationContext.ObjectInstance, null );

            if( valid != null && !String.IsNullOrWhiteSpace( v ) ) return null;

            if( valid != null && String.IsNullOrWhiteSpace( v ) ) return valid;

            return valid;
        }

        public void OnMetadataCreated( ModelMetadata metadata )
        {
            if( metadata.Model != null )
            {
                string filePath = (string)metadata.ContainerType.GetProperty( "FileRelativePath" ).GetValue( metadata.Model, null );
                _hasFilePath = !String.IsNullOrWhiteSpace( filePath );
            }
        }
    }
}
