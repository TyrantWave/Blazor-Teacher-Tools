using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
using Blazor.Extensions.Storage;
using TeacherTools.Services;

namespace TeacherTools
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStorage();
            services.AddSingleton<DayWordService>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
