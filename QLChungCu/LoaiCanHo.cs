namespace QLChungCu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiCanHo")]
    public partial class LoaiCanHo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiCanHo()
        {
            CanHoes = new HashSet<CanHo>();
        }

        [Key]
        public int MaLoai { get; set; }

        [StringLength(50)]
        public string TenLoai { get; set; }

        public decimal? GiaNgay { get; set; }

        public decimal? GiaThang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CanHo> CanHoes { get; set; }
    }
}
