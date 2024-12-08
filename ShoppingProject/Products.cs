using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartProject
{
    internal struct Products
    {
        private string _productName;
        private double _productPrice;

        public Products(string productName, double productPrice)
        {
            ProductName = productName;
            ProductPrice = productPrice;
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public double ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; }
        }

    }
}
