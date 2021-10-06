using Microsoft.EntityFrameworkCore;
using NutriPrep.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<Ushqimi> GetUshqimetMengjes(int mengjes, int nrMengjes)
        {
            var ushqimetB = new List<Ushqimi>();
            var shujtaId = _context.Shujta.Where(x => x.ShujtaRandomInt == nrMengjes
                && mengjes >= x.Kalori && mengjes < (x.Kalori + 19)).FirstOrDefault().ShujtaId;
            ushqimetB = _context.Ushqimis.Where(x => x.ShujtaId == shujtaId).ToList();

            return ushqimetB;
        }

        public List<Ushqimi> GetUshqimetDreke(int dreke, int nrDreke)
        {
            var ushqimetB = new List<Ushqimi>();
            ushqimetB = _context.Ushqimis.Where(x => x.Shujta.ShujtaRandomInt == nrDreke
                && (x.Shujta.Kalori + 19) < dreke && x.Shujta.Kalori >= dreke).ToList();

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
