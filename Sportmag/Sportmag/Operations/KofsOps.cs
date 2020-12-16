using Sportmag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportmag.Operations
{
    public static class KofsOps
    {
        public static List<Kofs> GetAllKofs()
        {
            return GetKofs("SELECT* FROM kind_of_sport  ;");
        }
        private static List<Kofs> GetKofs(string command)
        {
            var kofs = new List<Kofs>();
            var kofsObjs = DataBase.Select(command);

            foreach (var kof in kofsObjs)
                kofs.Add(new Kofs(kof));

            return kofs;
        }
    }
}
