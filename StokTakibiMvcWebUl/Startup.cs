using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using StokTakibiBusiness.Abstract;
using StokTakibiBusiness.Concrete;
using StokTakibiDataAccess.Abstract;
using StokTakibiDataAccess.Concrete.EntityFramework;

namespace StokTakibiMvcWebUl
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
            //Kiþi kimlik doðrulama gerektiren bir sayfaya eriþim saðlamaya çalýþýyorsa ama sisteme giriþ yapmadýysa login sayfasýna yönlendiriyor.
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.LoginPath = new PathString("/Kullanicilar/Login");
                    
                });


            //Yetkilendirme iþlemleri için yaptýk böylelikle controllerda [Authorize] tanýmlamamýza gerek kalmýyor
            services.AddMvc(config =>
            {
                
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy) );
                
               
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Rol", policy => policy.RequireRole("U"));
            });


            services.AddControllersWithViews();

            // Constuctorda IBrimService istiyorsa sen ona BirimManager üret
            services.AddSingleton<IBirimService, BirimManager>();


            services.AddSingleton<IKategoriService, KategoriManager>();
            services.AddSingleton<IMarkaService, MarkaManager>();
            services.AddSingleton<IMusteriService, MusteriManager>();
            services.AddSingleton<ISatisService, SatisManager>();
            services.AddSingleton<ISepetService, SepetManager>();
            services.AddSingleton<IUrunService, UrunManager>();

            services.AddSingleton<IKullaniciService, KullaniciManager>();
            services.AddSingleton<IKullaniciRolService, KullaniciRolManager>();
            services.AddSingleton<IRolService, RolManager>();



            services.AddSingleton<IBirimDal, EfBirimDal>();
            services.AddSingleton<IKategoriDal, EfKategoriDal>();
            services.AddSingleton<IMarkaDal, EfMarkaDal>();
            services.AddSingleton<IMusteriDal, EfMusteriDal>();
            services.AddSingleton<ISatisDal, EfSatisDal>();
            services.AddSingleton<ISepetDal, EfSepetDal>();
            services.AddSingleton<IUrunDal, EfUrunDal>();

            services.AddSingleton<IKullaniciDal, EfKullaniciDal>();
            services.AddSingleton<IKullaniciRolDal, EfKullaniciRolDal>();
            services.AddSingleton<IRolDal, EfRolDal>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();


            app.UseAuthorization();



            //app.UseAuthentication(options =>
            //{
            //    options.AutomaticAuthenticate = true;
            //    options.AutomaticChallenge = true;
            //    options.LoginPath = "/Kullanicilar/Login";
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Urunler}/{action=Index}/{id?}");
            });
        }
    }
}
