using NutriPrep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriPrep
{
    public interface IMealsRepository
    {
        public List<Ushqimi> GetUshqimet();
        public List<Ushqimi> GetUshqimetPerEleminimNePlan();
    }
}
