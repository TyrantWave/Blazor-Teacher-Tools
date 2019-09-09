using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace TeacherTools.Services
{
    public class WordInfoService
    {
        private readonly HttpClient http;
        private readonly Uri baseUrl = new Uri("https://wordsapiv1.p.mashape.com/words/");
         private WordInfo notFound = new WordInfo
        {
            Word = "Not Found",
            Pronunciation = new Pronunciation
            {
                All = "nɑt_faʊnd"
            },
            Syllables = new Syllables
            {
                Count = 2,
                List = new List<string> { "not", "found" },
            },
            Results = new List<Result> 
            {
                new Result
                {
                    Definition = "word not found",
                    PartOfSpeech = "404",
                    Synonyms = new List<string> { "unfound", "undiscovered" },
                    Antonyms = new List<string> { "found", "discovered" }
                }
            }
        };

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
            var resp = await http.GetAsync(
                Uri.EscapeUriString(request.ToString())
            );
            if (!resp.IsSuccessStatusCode) return NotFound(word);
            var respWord = await resp.Content.ReadAsStringAsync();
            return WordInfo.FromJson(respWord);
        }

        public async Task<WordInfo> GetRandomWordAsync()
        {
            var request = new UriBuilder(baseUrl);
            request.Query = "hasDetails=examples,definition&random=true";
            var resp = await http.GetStringAsync(request.ToString());
            return WordInfo.FromJson(resp);
        }

        public WordInfo NotFound(string query)
        {
            notFound.Results[0].Definition = $"word {query} not found";
            return notFound;
        }
    }
}