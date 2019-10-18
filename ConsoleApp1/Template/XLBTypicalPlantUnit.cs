namespace Template
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XLBTypicalPlantUnit")]
    public partial class XLBTypicalPlantUnit
    {
        [Key]
        public int TypicalPlantUnitID { get; set; }

        [Required]
        [StringLength(50)]
        public string TypicalPlantUnitName { get; set; }

        public int? CreationMode { get; set; }

        public Guid? TypicalPlantUnitGUID { get; set; }

        [StringLength(50)]
        public string TypicalPlantUnitTypeName { get; set; }
    }
}
