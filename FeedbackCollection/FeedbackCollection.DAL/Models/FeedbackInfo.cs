using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackCollection.DAL.Models
{
    public class FeedbackInfo
    {
        public string Post { get; set; }
        public string User { get; set; }
        public DateTime PostAddedOn { get; set; }
        public DateTime CommentsAddedOn { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
        public string Comment { get; set; }
    }
}
