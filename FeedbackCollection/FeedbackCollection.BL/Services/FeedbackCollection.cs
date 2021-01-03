using FeedbackCollection.DAL.Models;
using FeedbackCollection.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackCollection.BL.Services
{
    public class FeedbackCollection:IFeedbackCollection
    {
        private readonly IFeedbackCollectionRepository _feedbackCollectionRepository;
        public FeedbackCollection(IFeedbackCollectionRepository feedbackCollectionRepository)
        {
            _feedbackCollectionRepository = feedbackCollectionRepository;

        }
        public async Task<List<FeedbackInfo>> GetFeedbackInfos()
        {
            return _feedbackCollectionRepository.GetFeedbackCollenctionList();
            //return feedback;
        }
    }
}
