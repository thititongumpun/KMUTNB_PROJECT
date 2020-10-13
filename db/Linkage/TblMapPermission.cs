using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dded.db.Linkage
{
    [Table("TBL_MAP_PERMISSION")]
    public partial class TblMapPermission
    {
        [Key]
        [Column("PERMISSION_ID")]
        public Guid PermissionId { get; set; }
        [Column("OFFICER_ID")]
        public Guid? OfficerId { get; set; }
        [Column("MAP_MENU_ID")]
        public Guid? MapMenuId { get; set; }
        [Column("ACTIVE_FLAG")]
        public bool? ActiveFlag { get; set; }

        [ForeignKey(nameof(MapMenuId))]
        [InverseProperty(nameof(TblMapMenu.TblMapPermission))]
        public virtual TblMapMenu MapMenu { get; set; }
        [ForeignKey(nameof(OfficerId))]
        [InverseProperty(nameof(TblOfficer.TblMapPermission))]
        public virtual TblOfficer Officer { get; set; }
    }
}
