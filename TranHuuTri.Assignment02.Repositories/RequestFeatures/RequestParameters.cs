using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranHuuTri.Assignment02.Repositories.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string? SearchTerm { get; set; }
    }

    public class BookParameters : RequestParameters
    {
        //public string SearchTerm { get; set; }
    }
    public class AuthorParameters : RequestParameters
    {
        //public string SearchTerm { get; set; }
    }
    public class BookAuthorParameters : RequestParameters
    {
        //public string SearchTerm { get; set; }
    }
    public class PublisherParameters : RequestParameters
    {
        //public string SearchTerm { get; set; }
    }

    public class UserParameters : RequestParameters
    {
        //public string SearchTerm { get; set; }
    }

}
