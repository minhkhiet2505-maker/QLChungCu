namespace QLChungCu
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuDungDichVu")]
    public partial class SuDungDichVu
    {
        public int ID { get; set; }

        public int? MaHopDong { get; set; }

        public int? MaDV { get; set; }

        public decimal? GiaTien { get; set; }

        public DateTime? NgayDangKy { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual HopDong HopDong { get; set; }
    }
}
