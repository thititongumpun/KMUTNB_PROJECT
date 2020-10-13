using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dded.db.Linkage
{
    [Table("TBL_LOG")]
    public partial class TblLog
    {
        [Key]
        [Column("LOG_ID")]
        public Guid LogId { get; set; }
        [Column("CREATE_DATE", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column("MAPMENU_ID")]
        public Guid? MapmenuId { get; set; }
        [Column("DATA")]
        public string Data { get; set; }

        [ForeignKey(nameof(MapmenuId))]
        [InverseProperty(nameof(TblMapMenu.TblLog))]
        public virtual TblMapMenu Mapmenu { get; set; }
    }
}
