using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dded.db.Linkage
{
    public partial class ViewSubMenu
    {
        [Column("ID")]
        public Guid Id { get; set; }
        public int? MenuNo { get; set; }
        [Column("MenuName_th")]
        [StringLength(100)]
        public string MenuNameTh { get; set; }
        [Column("CITIZEN_ID")]
        [StringLength(13)]
        public string CitizenId { get; set; }
    }
}
