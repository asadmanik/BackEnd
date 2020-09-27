using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostBackend.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostAddedBy { get; set; }
        public DateTime PostAddedDate { get; set; }
        public int  counter { get; set; }
    }
}