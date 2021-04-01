using Microsoft.EntityFrameworkCore;
using MoreLinq;
using NutriPrep.Data;
using NutriPrep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriPrep.Repositories
{
    public class MealsRepository : IMealsRepository
    {
        private readonly NutriPrepContext _context;

        public MealsRepository(
            NutriPrepContext context    
        )
        {
            _context = context;
        }

        public List<Ushqimi> GetUshqimet()
        {
            var rand = new Random();
            var count = 0;
            var ushqimetB = new List<Ushqimi>();
            var ushqimetL = new List<Ushqimi>();
            var ushqimetD = new List<Ushqimi>();
            var ushqimet = new List<Ushqimi>();
            while (count < 7)
            {
                var shujtaRand = rand.Next(10, 12);

                ushqimetB = _context.Ushqimis.Where(x => x.Shujta.ShujtaRandomInt == shujtaRand 
                && (x.Shujta.Kalori + 19) < 580 && x.Shujta.Kalori >= 560).ToList();
                //ushqimetL = _context.Ushqimis.Where(x => x.Shujta.ShujtaRandomInt == shujtaRand
                //&& (x.Shujta.Kalori + 19) < 920 && x.Shujta.Kalori >= 900 && x.Shujta.Lloji == "L").ToList();
                //ushqimetD = _context.Ushqimis.Where(x => x.Shujta.ShujtaRandomInt == shujtaRand
                //&& (x.Shujta.Kalori + 19) < 700 && x.Shujta.Kalori >= 680 && x.Shujta.Lloji == "D").ToList();

                count++;
            }

            //foreach (var item in ushqimetB)
            //{
            //    ushqimet.Add(item);
            //}
            //foreach (var item in ushqimetL)
            //{
            //    ushqimet.Add(item);
            //}
            //foreach (var item in ushqimetD)
            //{
            //    ushqimet.Add(item);
            //}


            return ushqimetB;
        }

        public List<Ushqimi> GetUshqimetPerEleminimNePlan()
        {
            List<Ushqimi> lista = _context.Ushqimis.Include(x => x.Shujta).Where(x => x.Shujta.Lloji == "D"
           || x.Shujta.Lloji == "L").ToList();


            List<Ushqimi> listToReturn = new List<Ushqimi>();

            foreach (var item in lista)
            {
                listToReturn.Add(item);
            }

            return listToReturn;
        }
    }
}
