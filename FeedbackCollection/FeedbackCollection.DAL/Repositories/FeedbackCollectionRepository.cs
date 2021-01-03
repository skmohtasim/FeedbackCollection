using FeedbackCollection.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace FeedbackCollection.DAL.Repositories
{
    public class FeedbackCollectionRepository: DataContext,IFeedbackCollectionRepository
    {
        public FeedbackCollectionRepository(Config config) : base(config)
        {
        }



        public List<FeedbackInfo> GetFeedbackCollenctionList()
        {
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                string sqlQuery = "GetUserPostComments";
                DataTable dt = ExecuteStoreProcedureForDataTable(sqlQuery, sqlParameters);
                List<FeedbackInfo> studentDetails = new List<FeedbackInfo>();
                return ConvertDataTable<FeedbackInfo>(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
