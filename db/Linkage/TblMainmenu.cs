using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dded.db.Linkage
{
    [Table("TBL_MainMenu")]
    public partial class TblMainMenu
    {
        public TblMainMenu()
        {
            TblMapMenu = new HashSet<TblMapMenu>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        public int? MenuNo { get; set; }
        [Column("MenuName_th")]
        [StringLength(100)]
        public string MenuNameTh { get; set; }
        [Column("MenuShortName_th")]
        [StringLength(50)]
        public string MenuShortNameTh { get; set; }
        [Column("MenuName_en")]
        [StringLength(100)]
        public string MenuNameEn { get; set; }
        [Column("OfficeID")]
        [StringLength(50)]
        public string OfficeId { get; set; }
        [StringLength(500)]
        public string PageAddress { get; set; }
        public bool? Activeflag { get; set; }

        [InverseProperty("MainMenu")]
        public virtual ICollection<TblMapMenu> TblMapMenu { get; set; }
    }
}
