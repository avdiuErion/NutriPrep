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
            var ushqimetD = new List<Ushqimi>();
            var shujtaId = _context.Shujta.Where(x => x.ShujtaRandomInt == nrDreke
                && dreke >= x.Kalori && dreke < (x.Kalori + 19)).FirstOrDefault();

            var shujtaIdToUse = 0;

            if(shujtaId != null)
            {
                shujtaIdToUse = shujtaId.ShujtaId;
            }
            else
            {
                shujtaIdToUse = _context.Shujta.Where(x => x.ShujtaRandomInt == nrDreke).OrderByDescending(x => x.Kalori).FirstOrDefault().ShujtaId;
            }
            ushqimetD = _context.Ushqimis.Where(x => x.ShujtaId == shujtaIdToUse).ToList();

            return ushqimetD;
        }

        public List<Ushqimi> GetUshqimetDarke(int darke, int nrDarke)
        {
            var ushqimetD = new List<Ushqimi>();
            var shujtaId = _context.Shujta.Where(x => x.ShujtaRandomInt == nrDarke
                && darke >= x.Kalori && darke < (x.Kalori + 19)).FirstOrDefault();

            var shujtaIdToUse = 0;

            if (shujtaId != null)
            {
                shujtaIdToUse = shujtaId.ShujtaId;
            }
            else
            {
                shujtaIdToUse = _context.Shujta.Where(x => x.ShujtaRandomInt == nrDarke).OrderByDescending(x => x.Kalori).FirstOrDefault().ShujtaId;
            }
            ushqimetD = _context.Ushqimis.Where(x => x.ShujtaId == shujtaIdToUse).ToList();
            return ushqimetD;
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
