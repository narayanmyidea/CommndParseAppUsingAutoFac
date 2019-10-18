namespace WpfApp1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<XLBMacro> XLBMacroes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<XLBMacro>()
                .Property(e => e.MacroVersion)
                .IsUnicode(false);

            modelBuilder.Entity<XLBMacro>()
                .Property(e => e.MacroGuid)
                .IsUnicode(false);
        }
    }
}
