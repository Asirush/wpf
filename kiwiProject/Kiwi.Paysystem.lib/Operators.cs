namespace Kiwi.Paysystem.lib
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Operators
    {
        [Key]
        public int Id { get; set; }

        public string Phone { get; set; }

        public string Logo { get; set; }

        public string Name { get; set; }

        public double Precent { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
