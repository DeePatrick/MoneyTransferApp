using MoneyApp.Library.Internal.DataAccess;
using MoneyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyApp.Library.DataAccess
{
    public class TransactionData
    {
        public List<TransactionModel> GetTransaction()
        {

            SqlDataAccess sql = new SqlDataAccess();
            var output = sql.LoadData<TransactionModel, dynamic>("[dbo].[spTransaction_GetAll]", new { }, "MoneyApplication");
            return output;
        }

        public void SaveTransaction(TransactionModel item)
        {
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("[dbo].[spTransaction_Insert]", item, "MoneyApplication");
        }
    }
}

