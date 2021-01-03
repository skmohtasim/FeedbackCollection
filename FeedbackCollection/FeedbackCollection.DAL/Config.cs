using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackCollection.DAL
{
    public class Config
    {
        public Config(string connStr)
        {
            ConnectionString = connStr;
        }

        public string ConnectionString { get; private set; }


    }
}
