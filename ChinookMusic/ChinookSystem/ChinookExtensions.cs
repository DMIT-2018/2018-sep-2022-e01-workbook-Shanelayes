using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using ChinookSystem.DAL;
using ChinookSystem.BLL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
#endregion

namespace ChinookSystem
{
    //This class needs to be public so it can be used outside of this project
    //This class also needs to be static
    public static class ChinookExtensions
    {
        //Method name can be anything it must match the builder.services.xxxxx(options => .....)
        //Statement in your program.cs

        //the first parameter is the class that you are attempting to extend the second paraeter is the options value in your 
        //call statement, it is receivung the connection string for the application 
        //
        public static void ChinookSystemBackendDependencies(this IServiceCollection services,Action<DbContextOptionsBuilder>options)
        {
            //register the Dbcontext class with the service collection
            services.AddDbContext<ChinookContext>(options);

                //add any services that you create in the class library using .AddTransient<serviceclassname>(...);

            services.AddTransient<TrackServices>((serviceProvider) =>
            {
                //retrieve the registered DbContext done with AddDbContext
                var context = serviceProvider.GetRequiredService<ChinookContext>();
                return new TrackServices(context);
            });


            services.AddTransient<PlaylistTrackServices>((serviceProvider) =>
            {
                //retrieve the registered DbContext done with AddDbContext
                var context = serviceProvider.GetRequiredService<ChinookContext>();
                return new PlaylistTrackServices(context);
            });
        }
    }
}
