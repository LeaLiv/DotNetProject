using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalXml:IDal
    {
        public ICustomer Customer => new CustomerImplementation();

        public IProduct Product => new ProductImplemention();

        public ISale Sale => new SaleImplementation();

        static readonly DalXml instance => new DalXml();
        public static DalXml Instance { get{ return instance; } }

        private DalXml()
        {

        }
    }
}
