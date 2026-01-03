namespace QLChungCu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ToaNha")]
    public partial class ToaNha
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ToaNha()
        {
            CanHoes = new HashSet<CanHo>();
        }

        [Key]
        public int MaToa { get; set; }

        [StringLength(50)]
        public string TenToa { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CanHo> CanHoes { get; set; }
    }
}
