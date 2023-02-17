using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using ExerciseApp.Context;
using Microsoft.EntityFrameworkCore;

namespace ExerciseApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(option=> { option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); option.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull; });
            services.AddCors();
            services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase(databaseName: "Insure"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins("*");
                builder.WithMethods("GET", "PUT", "POST", "DELETE", "HEAD");
                builder.WithHeaders("Origin", "X-Requested-With", "content-type", "Accept");
                //builder.AllowCredentials();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
