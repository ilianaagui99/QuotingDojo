using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using System.Collections.Generic;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class QuotesController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        
        //See all quotes
        [HttpGet("/quotes")]
        public IActionResult QuotesGet()
        {
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM users"); 
            // To provide this data, we could use ViewBag or a View Model.  ViewBag shown here:
            ViewBag.Quotes = AllQuotes; //try View Model
            return View();
        }

        //Create a quote
        [HttpPost("/quotes")]
        public IActionResult QuotesPost(Quote newQuote)
        {
            // Post the data in newQuote to the DB
            string query = $"INSERT INTO users (name, quote) VALUES ('{newQuote.name}', '{newQuote.quote}')";
            DbConnector.Execute(query);
            // return the /quotes page
            return RedirectToAction("QuotesGet");
        }

    }
}