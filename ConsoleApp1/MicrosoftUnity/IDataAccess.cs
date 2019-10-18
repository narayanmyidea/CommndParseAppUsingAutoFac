using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftUnity
{
    public interface IDataAccess
    {
        string GetCurrentOrder();
        string GetAllOrders();
    }
  
    public class SqlDataAccess : IDataAccess
    {
        public string GetCurrentOrder()
        {
            return "Current order object from Sql Database";
        }

        public string GetAllOrders()
        {
            return "All orders from Sql Database";
        }
    }

    public class OracleDataAccess : IDataAccess
    {
        public string GetCurrentOrder()
        {
            return "Current order object from Oracle Database";
        }

        public string GetAllOrders()
        {
            return "All orders from oracle Database";
        }
    }
}
