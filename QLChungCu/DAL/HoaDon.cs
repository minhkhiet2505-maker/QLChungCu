namespace QLChungCu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }

        public int? MaHopDong { get; set; }

        public int? Thang { get; set; }

        public int? Nam { get; set; }

        public decimal? TienPhong { get; set; }

        public decimal? TienDienNuoc { get; set; }

        public decimal? TongTien { get; set; }

        public DateTime? NgayLap { get; set; }

        public int? TrangThai { get; set; }

        public int? SoDien { get; set; }

        public int? SoNuoc { get; set; }

        public virtual HopDong HopDong { get; set; }
    }
}
