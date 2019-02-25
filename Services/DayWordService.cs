
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
    }
}