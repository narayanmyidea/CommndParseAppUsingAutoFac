namespace Template
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XLBSegment")]
    public partial class XLBSegment
    {
        [Key]
        public int SegmentID { get; set; }

        [Required]
        [StringLength(255)]
        public string SegmentName { get; set; }

        public int PlantID { get; set; }

        [Required]
        [StringLength(255)]
        public string SegmentDescription { get; set; }

        public string PointRole { get; set; }

        public bool IsVisible { get; set; }

        public Guid? TypicalSegmentGuid { get; set; }

        public int? PlantUnitEquipmentBaseID { get; set; }

        public bool? SegmentDefault { get; set; }

        public int? DisplaySequence { get; set; }

        public bool IsSegment { get; set; }

        public int? ParentSegmentID { get; set; }

        [StringLength(255)]
        public string LibOptionID { get; set; }

        public Guid SegmentGuid { get; set; }

        public bool IsVisioSchematicFileUpdatedInPlantUnit { get; set; }
    }
}
