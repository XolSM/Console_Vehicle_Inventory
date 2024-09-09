using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MidTermAtHome
{
    internal class Vehicle
    {
        public string maker;
        public string model;
        public string year;
        private string mileage;
        public string price;

        public Vehicle(string _maker, string _model, string _year, string _mileage, string _price)
        {
            maker = _maker;
            model = _model;
            year = _year;
            mileage = _mileage;
            price = _price;
        }

        public string Mileage
        {
            get
            {
                return mileage;
            }

        }


        public double TaxRate()
        {
            int intPrice = int.Parse(price);
            double taxRate = 0;
            if (intPrice <= 2500)
            {
                taxRate = 0.05;
            }
            else if (intPrice <= 5500)
            {
                taxRate = 0.09;
            }
            else if (intPrice <= 79500)
            {
                taxRate = 0.14;
            }
            else
            {
                taxRate = 0.29;
            }
                return taxRate;
        }
        public double TotalPrice()
        {
            double intPrice =  double.Parse(price);
            double totalPrice = intPrice * (1 + TaxRate());
            return totalPrice;

        }

        public override string ToString() 
        {
            string result = maker + "\t" + model + "\t" + year 
                + "\t" + mileage + "\t" + "  $" + price;
            return result;
        }



    }
}
