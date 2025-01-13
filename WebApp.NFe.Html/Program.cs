using NFe.Danfe.Html.New.Services;
using NFe.Danfe.Html.New;

namespace WebApp.NFe.Html
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona suporte a Razor Pages e Controllers
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();

            builder.Services.AddScoped<DanfeViewHTML>();

            // Registra o DanfeService com a string de conexão obtida de appsettings.json
            builder.Services.AddScoped<IDanfeService>(provider =>
            {
                var connectionString = builder.Configuration.GetConnectionString("NFeDatabase");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("A string de conexão 'NFeDatabase' não foi configurada.");
                }

                return new DanfeService(connectionString);
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();

            app.Run();
        }
    }
}
