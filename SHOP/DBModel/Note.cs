namespace SHOP.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Note")]
    public partial class Note
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Header { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        public int ImportanceId { get; set; }

        public virtual Importance Importance { get; set; }
    }
}
