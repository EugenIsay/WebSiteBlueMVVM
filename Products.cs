using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteBlueMVVM
{
    public static class Products
    {
        public static List<Product> products = new List<Product>();
        public static void Add_Product(int saller, double cost, string name)
        {
            products.Add(new Product() { Saller = saller, Cost = cost, Name = name });
        }
        public static int GetUser(int i)
        {
            return products[i].Saller;
        }
        public static double GetCost(int i)
        {
            return products[i].Cost;
        }
        public static string Name(int i)
        {
            return products[i].Name;
        }
        public static int Amount(int i)
        {
            return products[i].Amount;
        }
        public static bool IsEmpty()
        {
            if (products.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public class Product
    {
        private int _saller;
        public int Saller
        { get { return _saller; } set { _saller = value; } }

        private double _cost = 00.00;
        public double Cost { get { return _cost; } set { _cost = value; } }

        private string _name = string.Empty;
        public string Name { get { return _name; } set { _name = value; } }

        private int _amount = 1;
        public int Amount { get { return _amount; } set { _amount = value; } }
    }
}
