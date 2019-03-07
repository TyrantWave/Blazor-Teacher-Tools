
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;

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
			var resp = await http.GetStringAsync(
				Uri.EscapeUriString(request.ToString())
			);
            return WordInfo.FromJson(resp);
		}

		public async Task<WordInfo> GetRandomWordAsync()
		{
			var request = new UriBuilder(baseUrl);
			request.Query = "hasDetails=examples,definition&random=true";
            var resp = await http.GetStringAsync(request.ToString());
            return WordInfo.FromJson(resp);
        }
	}
}