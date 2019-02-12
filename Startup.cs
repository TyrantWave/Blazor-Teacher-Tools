using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
using Blazor.Extensions.Storage;

namespace TeacherTools
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddStorage();
		}

		public void Configure(IBlazorApplicationBuilder app)
		{
			app.AddComponent<App>("app");
		}
	}
}
