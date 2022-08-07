using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylerHarker.Blogging.Models
{
    public class Blog
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string HtmlText { get; set; }
        public List<string> Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
