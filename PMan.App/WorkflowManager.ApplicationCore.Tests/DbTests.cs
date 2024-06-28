using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowManager.ApplicationCore.Tests
{
    public class DbTests
    {
        [Fact]
        public void CanCreate100DbConnections()
        {
            var range = Enumerable.Range(0, 100);
            var connection = new List<SqlConnection>();

            foreach (var item in range)
            {
                connection.Add(new SqlConnection());
            }

            Assert.True(connection.Count >= 100);
        }
    }
}
