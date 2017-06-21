using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerIndexViewModel
    {
        public IEnumerable<Customer> Customer { get; set; }
    }
}