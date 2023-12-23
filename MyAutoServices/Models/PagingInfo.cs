using System;

namespace MyAutoService.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int PageIndex { get; set; }
        public int ItemPerPage { get; set; }
        public int PageCount => (int)Math.Ceiling((decimal)TotalItems / ItemPerPage);
        public string UrlParam { get; set; }

    }
}
