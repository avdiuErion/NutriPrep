using Microsoft.EntityFrameworkCore;
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
            var shujtaRand = 1;
            var ushqimet = _context.Ushqimis.Where(x => x.Shujta.ShujtaRandomInt == shujtaRand && (x.Shujta.Kalori + 19) < 700 && x.Shujta.Kalori >= 680).ToList();

            return ushqimet;
        }
    }
}
