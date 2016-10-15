using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ClientViewModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "{0}字太長嘍, 長度不要超過{1}字元")]
        [DisplayName("名")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "{0}字太長嘍, 長度不要超過{1}字元")]
        [DisplayName("中間名")]
        [DisplayFormat(NullDisplayText = "白癡")]
        public string MiddleName { get; set; }

        [DisplayName("姓")]
        [Required]
        [StringLength(10, ErrorMessage = "{0}字太長嘍, 長度不要超過{1}字元")]
        public string LastName { get; set; }

        [DisplayName("性別")]
        [Required]
        [RegularExpression("[MF]", ErrorMessage = "{0}請填男性(M)或女性(F)")]
        public string Gender { get; set; }

        [DisplayName("生日")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:yyyy/MM/dd}", HtmlEncode = true, NullDisplayText = "白癡")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
    }
}