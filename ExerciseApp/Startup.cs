using ExerciseApp.Service;
using ExerciseApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

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
            services.AddControllers().AddJsonOptions(option=> { option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); option.JsonSerializerOptions.IgnoreNullValues = true; });
            services.AddCors();
            services.AddSingleton<IQuoteService, QuoteService>();
            services.AddSingleton<IInsuranceQuoteFactory, InsuranceQuoteFactory>();
            services.AddSingleton<InsuranceQuoteEngine, FullyCompInsuranceEngine>();
            services.AddSingleton<InsuranceQuoteEngine, ThirdPartyInsuranceEngine>();
            services.AddSingleton<InsuranceQuoteEngine, ThirdPartyFireAndTheftInsuranceEngine>();
            services.AddSingleton<InsuranceQuoteEngine, InvalidInsuranceEngine>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
        }
    }
}
