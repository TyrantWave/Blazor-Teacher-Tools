
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using TeacherTools.Credentials;

namespace TeacherTools.Services
{
	public class WordInfoService
	{
		private readonly HttpClient http;

		public WordInfoService(HttpClient client)
		{
			http = client;
		}
		public async Task<WordInfo> GetWordAsync()
		{
			return await http.GetJsonAsync<WordInfo>("sample-data/words-api.json");

		}

	}
}