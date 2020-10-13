using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dded.db.Linkage
{
    [Table("TBL_DEPARTMENT")]
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblOfficer = new HashSet<TblOfficer>();
        }

        [Key]
        [Column("DEPARTMENT_ID")]
        public Guid DepartmentId { get; set; }
        [Column("DEPARTMENT_CODE")]
        [StringLength(10)]
        public string DepartmentCode { get; set; }
        [Column("DEPARTMENT_NAME")]
        [StringLength(100)]
        public string DepartmentName { get; set; }
        [Column("ACTIVE_FLAG")]
        public bool? ActiveFlag { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<TblOfficer> TblOfficer { get; set; }
    }
}
