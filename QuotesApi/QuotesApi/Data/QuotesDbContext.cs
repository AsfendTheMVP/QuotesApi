using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using QuotesApi.Models;

namespace QuotesApi.Data
{
    public class QuotesDbContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }    
    }
}