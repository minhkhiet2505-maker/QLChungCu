namespace QLChungCu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CanHo")]
    public partial class CanHo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CanHo()
        {
            HopDongs = new HashSet<HopDong>();
        }

        [Key]
        [StringLength(20)]
        public string MaCanHo { get; set; }

        public int? MaToa { get; set; }

        public int? MaLoai { get; set; }

        public int? Tang { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public virtual LoaiCanHo LoaiCanHo { get; set; }

        public virtual ToaNha ToaNha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDong> HopDongs { get; set; }
    }
}
