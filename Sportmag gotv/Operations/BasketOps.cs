using Sportmag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportmag.Operations
{
    public class BasketOps
    {
        public static void PostBascet(int pers_id ,int sale_id)
        {
             PostBasket("INSERT INTO basket (preson_id,sale_id,count) VALUES(" + pers_id + "," + sale_id + ","+1+");");
        }
        public static List<Basket> GetIdBascet(int id)
        {
            return GetBasket("SELECT * FROM basket where preson_id=" + id + ";");
        }
        private static List<Basket> GetBasket( string command)
        {
            var basket = new List<Basket>();
            var basketobj = DataBase.Select(command);
            foreach (var b in basketobj)
                basket.Add(new Basket(b));
            return basket;
        }
        private static void PostBasket(string command)
        {
            var basketobj = DataBase.Select(command);
        }
        public static void PostDeletBascet(int id)
        {
            PostBasket("DELETE FROM basket WHERE preson_id=" + id + ";");
        }
    }
}
