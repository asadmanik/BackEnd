using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostBackend.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string CommentTitle { get; set; }
        public string CommentAddedBy { get; set; }
        public DateTime CommentAddedDate { get; set; }

        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}