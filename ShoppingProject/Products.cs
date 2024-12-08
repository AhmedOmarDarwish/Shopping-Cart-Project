using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartProject
{
    internal struct Products
    {
        private string _productName { get; set; }
        private double _productPrice { get; set; }

        public Products(string productName, double productPrice )
        {
            _productName = productName;
            _productPrice = productPrice;
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
