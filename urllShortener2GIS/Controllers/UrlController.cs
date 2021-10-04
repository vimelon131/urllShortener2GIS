using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using urllShortener2GIS.Data;
using urllShortener2GIS.Models;

namespace urllShortener2GIS.Controllers
{
    public class UrlController : Controller
    {
        private readonly UrlContext _context;
        public UrlController(UrlContext context)
        {
            _context = context;
        }
        public IActionResult Index(Url url)
        {
            return View(url);
        }

        public async Task<IActionResult> List()
        {
            return View(await _context.Url.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID, longURL")]Url url)
        {
            if (ModelState.IsValid)
            {
                var url1 = await _context.Url.FirstOrDefaultAsync(a => a.longURL == url.longURL);

                if (url1 == null)
                {
                    url.shortURL = getShortUrl();
                    var url2 = await _context.Url.FirstOrDefaultAsync(a => a.shortURL == url.shortURL);
                    while (url2 != null)
                    {
                        url.shortURL = getShortUrl();
                        url2 = await _context.Url.FirstOrDefaultAsync(a => a.shortURL == url.shortURL);
                    }
                    _context.Add(url);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), url);
                }
                else
                {
                    return RedirectToAction(nameof(Index), url1);
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // Methods
        private string getShortUrl()
        {
            UriBuilder newUri = new UriBuilder("https://localhost:44308/");
            string dictionary = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random rnd = new Random();
            newUri.Path = new string(Enumerable.Repeat(dictionary, 6).Select(x => x[rnd.Next(x.Length)]).ToArray());
            return newUri.ToString();
        }
        
    }
}
