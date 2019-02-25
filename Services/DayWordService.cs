
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TeacherTools.Services
{
    public class DayWordService
    {
        private readonly HttpClient http;
        public DayWordService(HttpClient client)
        {
            http = client;
        }
        public async Task<DayWord> GetWordAsync()
        {
            return await http.GetJsonAsync<DayWord>("sample-data/word.json");
        }

        public async Task<List<Hyphenation>> GetHyphenationAsync(string word)
        {
            return await http.GetJsonAsync<List<Hyphenation>>("sample-data/hyphenation.json");
        }

        public async Task<int> GetScrabbleScoreAsync(string word)
        {
            var response = await http.GetJsonAsync<ScrabbleScore>("sample-data/scrabble.json");
            return response.value;
        }
    }
}