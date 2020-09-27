﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BookListRazor.Pages
{
    public class IndexModel : PageModel //Inherited from page model
    {
        private readonly ILogger<IndexModel> _logger; 

        public IndexModel(ILogger<IndexModel> logger) //constructor
        {
            _logger = logger;
        }

        public void OnGet() //get method
        {

        }
    }
}
