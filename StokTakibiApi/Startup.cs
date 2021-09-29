using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StokTakibiBusiness.Abstract;
using StokTakibiBusiness.Concrete;
using StokTakibiDataAccess.Abstract;
using StokTakibiDataAccess.Concrete.EntityFramework;

namespace StokTakibiApi
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

            services.AddControllers();

            // Constuctorda IFirmaService istiyorsa sen ona FirmaManager üret
            services.AddSingleton<IFirmaService, FirmaManager>();


            services.AddSingleton<IBayiService, BayiManager>();
            services.AddSingleton<IBirimService, BirimManager>();
            services.AddSingleton<IKategoriService, KategoriManager>();
            services.AddSingleton<IMarkaService, MarkaManager>();
            services.AddSingleton<IMusteriService, MusteriManager>();
            services.AddSingleton<ISatisService, SatisManager>();
            services.AddSingleton<ISepetService, SepetManager>();
            services.AddSingleton<IUrunService, UrunManager>();


            services.AddSingleton<IFirmaDal, EfFirmaDal>();
            services.AddSingleton<IBayiDal, EfBayiDal>();
            services.AddSingleton<IBirimDal, EfBirimDal>();
            services.AddSingleton<IKategoriDal, EfKategoriDal>();
            services.AddSingleton<IMarkaDal, EfMarkaDal>();
            services.AddSingleton<IMusteriDal, EfMusteriDal>();
            services.AddSingleton<ISatisDal, EfSatisDal>();
            services.AddSingleton<ISepetDal, EfSepetDal>();
            services.AddSingleton<IUrunDal, EfUrunDal>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StokTakibiApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StokTakibiApi v1"));
            }

            app.UseHttpsRedirection();
             
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
