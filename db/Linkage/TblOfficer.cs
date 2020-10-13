using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dded.db.Linkage
{
    [Table("TBL_OFFICER")]
    public partial class TblOfficer
    {
        public TblOfficer()
        {
            TblMapPermission = new HashSet<TblMapPermission>();
        }

        [Key]
        [Column("OFFICER_ID")]
        public Guid OfficerId { get; set; }
        [Column("USERNAME")]
        public string Username { get; set; }
        [Column("CITIZEN_ID")]
        [StringLength(13)]
        public string CitizenId { get; set; }
        [Column("CARD_ID")]
        [StringLength(100)]
        public string CardId { get; set; }
        [Column("PIN_CODE")]
        [StringLength(10)]
        public string PinCode { get; set; }
        [Column("DEPARTMENT_ID")]
        public Guid? DepartmentId { get; set; }
        [Column("LEVEL_ID")]
        public int? LevelId { get; set; }
        [Column("CREATEDATE", TypeName = "datetime")]
        public DateTime? Createdate { get; set; }
        [Column("ACTIVE_FLAG")]
        public bool? ActiveFlag { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(TblDepartment.TblOfficer))]
        public virtual TblDepartment Department { get; set; }
        [ForeignKey(nameof(LevelId))]
        [InverseProperty(nameof(TblLevel.TblOfficer))]
        public virtual TblLevel Level { get; set; }
        [InverseProperty("Officer")]
        public virtual ICollection<TblMapPermission> TblMapPermission { get; set; }
    }
}
