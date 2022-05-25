namespace SHOP.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductOrder")]
    public partial class ProductOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }
        public int Sum => Quantity * Product.Price;

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
