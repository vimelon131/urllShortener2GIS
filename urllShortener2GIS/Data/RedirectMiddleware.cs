using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using urllShortener2GIS.Models;

namespace urllShortener2GIS.Data
{
    public class RedirectMiddleware
    {
        private readonly RequestDelegate _next;
        
        public RedirectMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task InvokeAsync(HttpContext context, UrlContext _context)
        {
            string url = context.Request.Path.Value.Trim();
            UriBuilder uri = new UriBuilder("https://localhost:44308/");
            uri.Path = url;
            List<Url> allUrls = await _context.Url.ToListAsync();
            Url longURL = allUrls.Find(x => x.shortURL == uri.ToString());
            if (longURL != null)
            {
                context.Response.Redirect(longURL.longURL);
            }
            else
            {
                await _next.Invoke(context);
            }

        }
    }
}
