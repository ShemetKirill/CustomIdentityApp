using CustomIdentityApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentityApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(opts=>
            {
                opts.Password.RequireNonAlphanumeric = false; // ����� �� �� ���������-�������� �������
                opts.Password.RequireLowercase = true;  // ��������� �� ������� � ������ ��������               
                opts.Password.RequireUppercase = false;  //��������� �� ������� � ������� �������� 
                opts.Password.RequireDigit = true; // ������� �� ����� 

                opts.User.RequireUniqueEmail = true; //������ �� ���� ���������� Email
                opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz1234567890"; //���������� ������� 

            })
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddControllersWithViews();


        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    // ����������� ��������������
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}