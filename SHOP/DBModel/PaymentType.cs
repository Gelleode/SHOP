namespace SHOP.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentType")]
    public partial class PaymentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BankAccountNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string BankName { get; set; }

        public int ClientId { get; set; }

        public int OrderId { get; set; }

        public virtual Client Client { get; set; }

        public virtual Order Order { get; set; }
    }
}
