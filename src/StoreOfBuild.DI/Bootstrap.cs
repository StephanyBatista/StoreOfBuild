using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Data;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Data.Contexts;
using StoreOfBuild.Data.Repositories;
using StoreOfBuild.Domain.Sales;
using StoreOfBuild.Data.Identity;
using StoreOfBuild.Domain.Account;

namespace StoreOfBuild.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conection));
            
            services.AddIdentity<ApplicationUser, IdentityRole>(config => {

                    config.Password.RequireDigit = false;
                    config.Password.RequiredLength = 3;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    //Não existe mais essa opção no Core 2.1
                    //config.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

            services.AddSingleton(typeof(IRepository<Product>), typeof(ProductRepository));
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));            
            services.AddSingleton(typeof(IAuthentication), typeof(Authentication));
            services.AddSingleton(typeof(IManager), typeof(Manager));
            services.AddSingleton(typeof(CategoryStorer));
            services.AddSingleton(typeof(ProductStorer));
            services.AddSingleton(typeof(SaleFactory));
            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
