using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostBackend.Models
{
    public class vmPost
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostAddedBy { get; set; }
        public DateTime PostAddedDate { get; set; }
        public virtual List<Comment> Comments { get; set; }

    }
}