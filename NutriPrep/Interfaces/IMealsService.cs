using NutriPrep.DTOs;
using NutriPrep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriPrep.Interfaces
{
    public interface IMealsService
    {
        Task<List<Ushqimi>> GetPlan(PayLoadDTO payload);
    }
}
