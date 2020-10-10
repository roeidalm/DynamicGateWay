using System.ServiceModel;
using DynamicGateWay;
using DynamicGateWay.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SoapCore;

namespace DynamicGateWay {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddSingleton<IServiceRun, SampleService> ();
            services.AddSoapCore ();
            services.AddControllers ();
            services.AddControllers ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory) {
            app.UseSoapEndpoint<IServiceRun> ("/ServiceOne.svc", new BasicHttpBinding (), SoapSerializer.DataContractSerializer);
            app.UseSoapEndpoint<IServiceRun> ("/ServiceOne.asmx", new BasicHttpBinding (), SoapSerializer.XmlSerializer);

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}