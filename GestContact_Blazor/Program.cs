using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace GestContact_Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //List injectée dans le fake service
            builder.Services.AddSingleton<IList<Contact>>((sp) => new List<Contact>()
            {
                new Contact() { Id = 1, Nom = "Doe", Prenom = "John", Anniversaire = new DateTime(1970,1,1) },
                new Contact() { Id = 2, Nom = "Doe", Prenom = "Jane", Anniversaire = new DateTime(1970,1,1) },
                new Contact() { Id = 3, Nom = "Smith", Prenom = "Hannibal", Anniversaire = new DateTime(1970,1,1) },
                new Contact() { Id = 4, Nom = "Hanks", Prenom = "Tom", Anniversaire = new DateTime(1970,1,1) },
                new Contact() { Id = 5, Nom = "Fonda", Prenom = "Jane", Anniversaire = new DateTime(1970,1,1) },
                new Contact() { Id = 6, Nom = "Cruise", Prenom = "Tom", Anniversaire = new DateTime(1970,1,1) }
            });
            builder.Services.AddScoped<IContactRepository, FakeContactService>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
