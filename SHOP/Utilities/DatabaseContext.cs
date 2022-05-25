using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOP.DBModel;

namespace SHOP
{
    internal class DatabaseContext
    {
        public static ShopDB db = new ShopDB();
    }
}
