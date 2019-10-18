using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MicrosoftUnity
{
    public class OrderController: IOrderController
    {
       IDataAccess _dataAccess;

        public OrderController()
        {
           // _dataAccess = dataAccess;
        }

        [InjectionMethod]
        private void gg([Dependency("SQL")] IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void PrintCurrentOrder()
        {
        //    Console.WriteLine(_dataAccess.GetCurrentOrder());
        }

        public void PrintAllOrders()
        {
          // Console.WriteLine(_dataAccess.GetAllOrders());
        }
    }

    public interface IOrderController
    {
        void PrintCurrentOrder();
        void PrintAllOrders();
    }
}
