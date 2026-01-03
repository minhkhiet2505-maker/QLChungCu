namespace QLChungCu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            SuDungDichVus = new HashSet<SuDungDichVu>();
        }

        [Key]
        public int MaDV { get; set; }

        [StringLength(50)]
        public string TenDV { get; set; }

        // --- QUAN TRỌNG: TÔI ĐÃ XÓA DÒNG 'GiaTien' Ở ĐÂY ĐỂ KHỚP VỚI DATABASE ---

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuDungDichVu> SuDungDichVus { get; set; }
    }
}