using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dded.db.Linkage
{
    [Table("TBL_Token")]
    public partial class TblToken
    {
        public string Token { get; set; }
        public bool? Activeflag { get; set; }
    }
}
