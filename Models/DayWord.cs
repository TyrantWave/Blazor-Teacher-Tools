using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeacherTools.Services
{
    public class ContentProvider
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Example
    {
        public string url { get; set; }
        public string text { get; set; }
        public string title { get; set; }
        public int id { get; set; }
    }

    public class Definition
    {
        public string text { get; set; }
        public string partOfSpeech { get; set; }
        public string source { get; set; }
    }

    public class DayWord
    {
        public int id { get; set; }
        public string word { get; set; }
        public ContentProvider contentProvider { get; set; }
        public DateTime publishDate { get; set; }
        public string note { get; set; }
        public List<Example> examples { get; set; }
        public List<Definition> definitions { get; set; }
    }
}
