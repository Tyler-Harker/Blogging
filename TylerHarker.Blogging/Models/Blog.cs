using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylerHarker.Blogging.Models
{
    public class Blog
    {
        public Blog(string title, string htmlText, List<string> tags = null)
        {
            Title = title;
            HtmlText = htmlText;

            if(tags is not null)
            {
                Tags = tags;
            }
        }

        public Guid Id { get; protected set; } = Guid.Empty;
        public bool IsActive { get; protected set; } = true;
        public string Title { get; protected set; }
        public string HtmlText { get; protected set; }
        public List<string> Tags { get; protected set; } = new List<string>();
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; protected set; } = DateTime.UtcNow;
    }
}
