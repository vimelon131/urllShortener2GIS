using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace urllShortener2GIS.Data
{
    public class UrlContext : DbContext
    {
        public UrlContext(DbContextOptions<UrlContext> options)
           : base(options)
        {
        }

        public DbSet<urllShortener2GIS.Models.Url> Url { get; set; }
    }
}
