using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuotesApi.Data;
using QuotesApi.Models;

namespace QuotesApi.Controllers
{
    public class QuotesController : ApiController
    {
        QuotesDbContext quotesDbContext = new QuotesDbContext();
        // GET: api/Quotes
        [HttpGet]
        public IHttpActionResult LoadQuotes(string sort)
        {
            IQueryable<Quote> quotes;
            switch (sort)
            {
                case "desc":
                    quotes = quotesDbContext.Quotes.OrderByDescending(q => q.CreatedAt);
                    break;
                case "asc":
                    quotes = quotesDbContext.Quotes.OrderBy(q => q.CreatedAt);
                    break;
                default:
                    quotes = quotesDbContext.Quotes;
                    break;
            }
            return Ok(quotes);
        }

        [HttpGet]
        [Route("api/Quotes/PagingQuote/{pageNumber=1}/{pageSize=5}")]
        public IHttpActionResult PagingQuote(int pageNumber, int pageSize)
        {
            var quotes = quotesDbContext.Quotes.OrderBy(q => q.Id);
            return Ok(quotes.Skip((pageNumber - 1) * pageSize).Take(pageSize));
        }

        [HttpGet]
        [Route("api/Quotes/SearchQuote/{type=}")]
        public IHttpActionResult SearchQuote(string type)
        {
            var quotes = quotesDbContext.Quotes.Where(q => q.Type.StartsWith(type));
            return Ok(quotes);
        }

        // GET: api/Quotes/5
        [HttpGet]
        public IHttpActionResult LoadQuote(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        // POST: api/Quotes
        public IHttpActionResult Post([FromBody]Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            quotesDbContext.Quotes.Add(quote);
            quotesDbContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Quotes/5
        public IHttpActionResult Put(int id, [FromBody]Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = quotesDbContext.Quotes.FirstOrDefault(q => q.Id == id);
            if (entity == null)
            {
                return BadRequest("No record found against this id");
            }
            entity.Title = quote.Title;
            entity.Author = quote.Author;
            entity.Description = quote.Description;
            quotesDbContext.SaveChanges();
            return Ok("Record updated successfully...");
        }

        // DELETE: api/Quotes/5
        public IHttpActionResult Delete(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return BadRequest("No record found against this id"); // you can also return NotFound(); method here....
            }
            quotesDbContext.Quotes.Remove(quote);
            quotesDbContext.SaveChanges();
            return Ok("Quote deleted");
        }
    }
}
