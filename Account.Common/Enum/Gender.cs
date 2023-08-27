using System.ComponentModel.DataAnnotations;

namespace Account.Common.Enum;

public enum Gender
{
    [Display(Name = "مرد")]
    Male = 1,
    
    [Display(Name = "زن")]
    Female = 2
}