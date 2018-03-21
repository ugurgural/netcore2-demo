using System;
using NetCore2Demo.Entities.Base;

namespace NetCore2Demo.Entities.Domain
{
    public class Product : BaseEntity
    {
        public Product()
        {
            this.CreatedDate = DateTime.Now;
            this.IsActive = true;
        }

        public int ProductId { get; set; }
        public int VariantId { get; set; }
        public int? ColorGroup { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
    }
}