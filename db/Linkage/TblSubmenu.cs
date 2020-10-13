using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dded.db.Linkage
{
    [Table("TBL_Submenu")]
    public partial class TblSubmenu
    {
        public TblSubmenu()
        {
            TblMapColumn = new HashSet<TblMapColumn>();
            TblMapMenu = new HashSet<TblMapMenu>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        public int? MenuNo { get; set; }
        [Column("MenuName_th")]
        [StringLength(100)]
        public string MenuNameTh { get; set; }
        [Column("MenuName_en")]
        [StringLength(100)]
        public string MenuNameEn { get; set; }
        [StringLength(500)]
        public string ServiceAddress { get; set; }
        [Column("OfficeID")]
        [StringLength(50)]
        public string OfficeId { get; set; }
        [Column("ServiceID")]
        [StringLength(50)]
        public string ServiceId { get; set; }
        [StringLength(50)]
        public string Version { get; set; }
        public bool? Activeflag { get; set; }
        public int? ServiceQty { get; set; }
        public short? ServiceFormatType { get; set; }

        [InverseProperty("SubMenu")]
        public virtual ICollection<TblMapColumn> TblMapColumn { get; set; }
        [InverseProperty("SubMenu")]
        public virtual ICollection<TblMapMenu> TblMapMenu { get; set; }
    }
}
