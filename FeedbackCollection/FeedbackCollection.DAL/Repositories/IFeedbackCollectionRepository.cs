using FeedbackCollection.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackCollection.DAL.Repositories
{
    public interface IFeedbackCollectionRepository
    {
        public List<FeedbackInfo> GetFeedbackCollenctionList();
    }
}
