using Dynamic_Search.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dynamic_Search.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMongoCollection<SearchItem> _suggestionCollection;

        public SearchController(IMongoDatabase database)
        {
            _suggestionCollection = database.GetCollection<SearchItem>("Suggestions");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string query)
        {
            var suggestions = await _suggestionCollection
                .Find(s => s.Name.Contains(query) || s.Phone.Contains(query) || s.Email.Contains(query))
                .Limit(10) 
                .Project(s => s.Name)
                .ToListAsync();

             if (suggestions.Count == 0)
            {
                suggestions.Add("No suggestions");
            }

            return Json(suggestions);
        }
    }
}
