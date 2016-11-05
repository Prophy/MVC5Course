﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models.ViewModels
{
    public class ProductViewModel : IValidatableObject //TODO: 再實作
    //public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Stock { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Stock < 100 && this.Price > 20)
            {
                yield return new ValidationResult("庫存與商品金額的條件錯誤", new string[] { "Price" });
            }
        }
    }
}