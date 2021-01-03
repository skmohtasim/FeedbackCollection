using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FeedbackCollection.DAL
{
    public class DataContext : IDisposable
    {
        #region Private Variables

        private SqlDataAdapter _dbAdapter;
        private readonly string _connectionString;
        private bool _disposed = false;

        #endregion

        #region Public Variables

        //public List<SqlParameter> SqlParameters = new List<SqlParameter>();
        //public string SqlQuery;        

        #endregion


        #region Constructor

        public DataContext(Config config)
        {
            _dbAdapter = new SqlDataAdapter();
            _dbAdapter.SelectCommand = new SqlCommand();
            _dbAdapter.SelectCommand.Connection = new SqlConnection(config.ConnectionString);
        }

        #endregion

        #region Public Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void OpenConnection()
        {
            if (_dbAdapter.SelectCommand.Connection.State == ConnectionState.Broken || _dbAdapter.SelectCommand.Connection.State == ConnectionState.Closed)
            {
                _dbAdapter.SelectCommand.Connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_dbAdapter.SelectCommand.Connection.State == ConnectionState.Broken || _dbAdapter.SelectCommand.Connection.State == ConnectionState.Open)
            {
                _dbAdapter.SelectCommand.Connection.Close();
                //_dbAdapter.SelectCommand.Connection.Dispose();
                _dbAdapter.SelectCommand.Parameters.Clear();
            }
        }

        public DataTable ExecuteQueryForDataTable(string queryString)
        {
            DataTable dtResult = new DataTable();
            try
            {
                OpenConnection();
                var command = _dbAdapter.SelectCommand;
                command.CommandText = queryString;
                command.CommandType = CommandType.Text;
                _dbAdapter.Fill(dtResult);
                return dtResult;
            }
            finally
            {
                CloseConnection();
            }

        }

        public DataTable ExecuteStoreProcedureForDataTable(string spName, List<SqlParameter> sqlParameters)
        {
            DataTable dtResult = new DataTable();
            try
            {
                OpenConnection();
                var command = _dbAdapter.SelectCommand;
                command.CommandText = spName;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlParameters.ToArray());
                _dbAdapter.Fill(dtResult);
                //command.Parameters.Clear();
                return dtResult;
            }
            finally
            {
                CloseConnection();
            }

        }

        public int ExecuteNonQuery(string queryString)
        {
            try
            {
                OpenConnection();
                var command = _dbAdapter.SelectCommand;
                command.CommandText = queryString;
                command.CommandType = CommandType.Text;
                return command.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }

        }

        public int ExecuteNonQuerySqlText(string queryString, List<SqlParameter> sqlParameters)
        {

            try
            {
                OpenConnection();
                var command = _dbAdapter.SelectCommand;
                command.CommandText = queryString;
                command.CommandType = CommandType.Text;
                command.Parameters.AddRange(sqlParameters.ToArray());
                return command.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }

        }

        public int ExecuteNonQueryStoreProcedure(string spName, List<SqlParameter> sqlParameters)
        {
            try
            {
                OpenConnection();
                var command = _dbAdapter.SelectCommand;
                command.CommandText = spName;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlParameters.ToArray());
                return command.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }

        }

        //public void AddParameter(string name, object value = null)
        //{
        //    var sqlParameter = new SqlParameter(name, value);
        //    SqlParameters.Add(sqlParameter);
        //}


        #endregion

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (_dbAdapter != null)
                {
                    if (_dbAdapter.SelectCommand != null)
                    {
                        if (_dbAdapter.SelectCommand.Connection != null)
                        {
                            _dbAdapter.SelectCommand.Parameters.Clear();
                            _dbAdapter.SelectCommand.Connection.Close();
                            _dbAdapter.SelectCommand.Connection.Dispose();
                        }

                        _dbAdapter.SelectCommand.Dispose();
                    }

                    _dbAdapter.Dispose();
                    _dbAdapter = null;
                }
            }

            _disposed = true;
        }

        #endregion

    }
}
