using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dded.db.Linkage
{
    [Table("TBL_MapColumn")]
    public partial class TblMapColumn
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("SubMenuID")]
        public Guid? SubMenuId { get; set; }
        public string ColumnName { get; set; }
        [Column("ColumnDESC")]
        public string ColumnDesc { get; set; }
        public int? ColumnLevel { get; set; }
        public bool? ActiveFlag { get; set; }
        public int? No { get; set; }
        [StringLength(50)]
        public string ColumnDateFormat { get; set; }
        [StringLength(50)]
        public string ColumnTimeFormat { get; set; }
        public bool? ColumnTimestamp { get; set; }
        [StringLength(50)]
        public string ColumnDateTimeFormat { get; set; }
        [StringLength(50)]
        public string ColumnFileFormat { get; set; }
        [Column("isCitizenID")]
        public bool? IsCitizenId { get; set; }
        [Column("startColor")]
        public short? StartColor { get; set; }
        [Column("externalLink")]
        public string ExternalLink { get; set; }
        [Column("moneyFormat")]
        public bool? MoneyFormat { get; set; }
        [Column("underline")]
        public bool? Underline { get; set; }

        [ForeignKey(nameof(SubMenuId))]
        [InverseProperty(nameof(TblSubmenu.TblMapColumn))]
        public virtual TblSubmenu SubMenu { get; set; }
    }
}
