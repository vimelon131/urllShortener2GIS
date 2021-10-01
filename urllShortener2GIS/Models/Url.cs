using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace urllShortener2GIS.Models
{
    public class Url
    {
        public int ID { get; set; }
        
        [UrlAttribute]
        public string shortURL { get; set; }
        [UrlAttribute]
        public string longURL { get; set; }
    }
}
