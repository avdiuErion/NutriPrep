using System;
using System.Collections.Generic;

#nullable disable

namespace NutriPrep.Models
{
    public partial class Ushqimi
    {
        public int ShujtaUshqimId { get; set; }
        public string EmriUshqimit { get; set; }
        public int? Kalori { get; set; }
        public int? ShujtaId { get; set; }

        public virtual Shujtum Shujta { get; set; }
    }
}
