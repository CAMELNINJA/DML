using Sportmag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sportmag.Operations
{
    public static class SaleOps
    {
        public static List<Sale> GetSearchSales(string search)
        {
            return GetAllSales().Where(s => Regex.IsMatch((s.Name + s.Kind_of_sport + s.Price).ToLower(), Regex.Replace(search, @"[^\d\w]", "").ToLower())).ToList();
        }
        public static Sale GetIdSale(int id)
        {
            return GetSales("SELECT * FROM sale WHERE id = " + id + " LIMIT 1;").FirstOrDefault();
        }

        public static List<Sale> GetIdSales(int id)
        {
            return GetSales("SELECT * FROM sale WHERE kof_id = " + id + ";");
        }

        public static List<Sale> GetAllSales()
        {
            return GetSales("SELECT * FROM sale ;");
        }

        private static List<Sale> GetSales(string command)
        {
            var sales = new List<Sale>();
            var salesObjs = DataBase.Select(command);

            foreach (var sale in salesObjs)
                sales.Add(new Sale(sale));

            return sales;
        }

    }
}
