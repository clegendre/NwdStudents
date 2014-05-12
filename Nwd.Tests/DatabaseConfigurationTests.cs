using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Data.Entity;
using Nwd.BackOffice.Model;
using Nwd.FrontOffice.Model;

namespace Nwd.Tests
{
    [TestFixture]
    public class DatabaseConfigurationTests
    {
        [Test]
        public void Database_Should_Always_Be_Created()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<NwdMusikEntities>());
            Database.SetInitializer( new DropCreateDatabaseAlways<NwdFrontOfficeContext>() );

            using (var ctx = new NwdMusikEntities())
            {
                ctx.Database.Initialize(true);
                Assert.That(ctx.Database.Exists());
                Console.WriteLine(ctx.Database.Connection.ConnectionString);
            }
            using( var ctx = new NwdFrontOfficeContext() )
            {
                ctx.Database.Initialize( true );
                Assert.That( ctx.Database.Exists() );
                Console.WriteLine( ctx.Database.Connection.ConnectionString );
            }
        }
    }
}
