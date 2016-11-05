namespace MVC5Course.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ProductName.ToUpper().Contains("RICKY"))
            {
                yield return new ValidationResult("不可褻瀆神明", new string[] { "ProductName" });
            }

            yield break;
        }
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }

        [StringLength(80, ErrorMessage = "欄位長度不得大於 80 個字元")]

        [Required]
        public string ProductName { get; set; }

        [Required]
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }

        [Required]
        public Nullable<decimal> Stock { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        [StringLength(100, ErrorMessage = "欄位長度不得大於 100 個字元")]
        public string 註解 { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
