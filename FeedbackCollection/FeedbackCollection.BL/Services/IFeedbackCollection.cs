using FeedbackCollection.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackCollection.BL.Services
{
    public interface IFeedbackCollection
    {
        public Task<List<FeedbackInfo>> GetFeedbackInfos(); 
    }

    
}
