using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonafe.SGI.Domain.Model.Blog
{
    public class BlogPost
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UserId { get; set; }
    }
}
