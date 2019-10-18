namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XLBMacro")]
    public partial class XLBMacro
    {
        [Key]
        public int MacroID { get; set; }

        [Required]
        [StringLength(50)]
        public string MacroName { get; set; }

        public string MacroXML { get; set; }

        [Required]
        [StringLength(50)]
        public string MacroVersion { get; set; }

        public int MacroType { get; set; }

        [Required]
        [StringLength(64)]
        public string MacroGuid { get; set; }
    }
}
