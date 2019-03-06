
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using TeacherTools.Credentials;
namespace TeacherTools.Services
{
	public class WordInfoService
	{
		private readonly HttpClient http;
		private readonly Uri baseUrl = new Uri("https://wordsapiv1.p.mashape.com/words/");

		public WordInfoService(HttpClient client)
		{
			http = client;
			http.DefaultRequestHeaders.Accept.Clear();
			http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			http.DefaultRequestHeaders.Add("X-Mashape-Key", Credentials.Credentials.WordsApiKey);
		}

		public async Task<WordInfo> GetWordAsync(string word)
		{
			var request = new Uri(baseUrl, word);
			Console.WriteLine(Uri.EscapeUriString(request.ToString()));
			WordInfo result = await http.GetJsonAsync<WordInfo>(Uri.EscapeUriString(request.ToString()));
			Console.WriteLine(result.Word);
			return result;
		}

		public async Task<WordInfo> GetRandomWordAsync()
		{
			var request = new UriBuilder(baseUrl);
			request.Query = "hasDetails=examples,definition&random=true";
			return await http.GetJsonAsync<WordInfo>(request.ToString());
		}
	}
}