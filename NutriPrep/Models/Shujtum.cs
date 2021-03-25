using System;
using System.Collections.Generic;

#nullable disable

namespace NutriPrep.Models
{
    public partial class Shujtum
    {
        public int ShujtaId { get; set; }
        public string EmriShujtes { get; set; }
        public int? Kalori { get; set; }
        public int? ShujtaRandomInt { get; set; }
    }
}
