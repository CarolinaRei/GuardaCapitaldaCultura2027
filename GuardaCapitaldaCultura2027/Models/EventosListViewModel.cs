using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardaCapitaldaCultura2027.Models
{
    public class EventosListViewModel: PagingInfo
    {
        public const int DEFAULT_PAGE_SIZE = 5;
        public const int NUMBER_PAGES_SHOW_BEFORE_AFTER = 5;

        public int TotalItems { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    }

}
