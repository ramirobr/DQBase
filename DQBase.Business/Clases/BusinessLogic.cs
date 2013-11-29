using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DQBase.Business
{
    public partial class BusinessLogic
    {
        private string _connectionString;

        public string ConnectionString
        {
            set { _connectionString = value; }
            get { return string.IsNullOrEmpty(_connectionString) ? ConfigurationManager.ConnectionStrings["DQBaseContext"].ToString() : _connectionString; }
        }
        
    }
}
