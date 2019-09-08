using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

// using Blazor.Extensions.Storage;
using Blazored.LocalStorage;
using TeacherTools.Services;

namespace TeacherTools
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddBlazoredLocalStorage();
			services.AddSingleton<WordInfoService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
