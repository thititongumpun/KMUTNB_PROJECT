using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dded.db.Linkage
{
    [Table("TBL_MapMenu")]
    public partial class TblMapMenu
    {
        public TblMapMenu()
        {
            TblLog = new HashSet<TblLog>();
            TblMapPermission = new HashSet<TblMapPermission>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("MainMenuID")]
        public Guid MainMenuId { get; set; }
        [Column("SubMenuID")]
        public Guid SubMenuId { get; set; }
        public int? No { get; set; }
        public bool? ActiveFlag { get; set; }

        [ForeignKey(nameof(MainMenuId))]
        [InverseProperty(nameof(TblMainMenu.TblMapMenu))]
        public virtual TblMainMenu MainMenu { get; set; }
        [ForeignKey(nameof(SubMenuId))]
        [InverseProperty(nameof(TblSubmenu.TblMapMenu))]
        public virtual TblSubmenu SubMenu { get; set; }
        [InverseProperty("Mapmenu")]
        public virtual ICollection<TblLog> TblLog { get; set; }
        [InverseProperty("MapMenu")]
        public virtual ICollection<TblMapPermission> TblMapPermission { get; set; }
    }
}
