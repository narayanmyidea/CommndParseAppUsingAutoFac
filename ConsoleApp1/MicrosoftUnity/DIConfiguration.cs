using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MicrosoftUnity
{
    internal static class DIConfiguration
    {
        internal static IUnityContainer container;
        public static void Configure()
        {
            container=new UnityContainer();
            container.RegisterType<IDataAccess, SqlDataAccess>("SQL");
            container.RegisterType<IDataAccess, OracleDataAccess>("Oracle");
            //container.RegisterType<IOrderController, OrderController>();
            container.RegisterType<IOrderController, OrderController>();
        }
    }
}
