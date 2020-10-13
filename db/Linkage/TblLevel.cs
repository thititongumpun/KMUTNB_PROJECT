using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dded.db.Linkage
{
    [Table("TBL_LEVEL")]
    public partial class TblLevel
    {
        public TblLevel()
        {
            TblOfficer = new HashSet<TblOfficer>();
        }

        [Key]
        [Column("LEVEL_ID")]
        public int LevelId { get; set; }
        [Column("LEVEL_NAME")]
        public string LevelName { get; set; }
        [Column("ACTIVE_FLAG")]
        public bool? ActiveFlag { get; set; }

        [InverseProperty("Level")]
        public virtual ICollection<TblOfficer> TblOfficer { get; set; }
    }
}
