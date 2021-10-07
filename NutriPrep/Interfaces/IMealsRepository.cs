using NutriPrep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriPrep
{
    public interface IMealsRepository
    {
        public List<Ushqimi> GetUshqimetMengjes(int mengjes, int nrMengjes);
        public List<Ushqimi> GetUshqimetDreke(int dreke, int nrDreke);
        public List<Ushqimi> GetUshqimetDarke(int darke, int nrDarke);
        public List<Ushqimi> GetUshqimetPerEleminimNePlan();
    }
}
