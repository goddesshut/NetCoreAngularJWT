using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class PagedListParameters
    {
        public IList<PageOrder> Orders { get; set; } = new List<PageOrder>();

        public Page Page { get; set; } = new Page();
    }
}
