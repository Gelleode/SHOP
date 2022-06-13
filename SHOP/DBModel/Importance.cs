using System.IO;

namespace SHOP.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Importance")]
    public partial class Importance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Importance()
        {
            Note = new HashSet<Note>();
        }

        public int Id { get; set; }

        [Required] [StringLength(50)] public string Title { get; set; }
        [Required] [StringLength(50)] public string PhotoPath { get; set; }

        public byte[] Photo => File.ReadAllBytes(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + PhotoPath);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Note> Note { get; set; }
    }
}
