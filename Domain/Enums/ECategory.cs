using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductManager.Domain.Enums;

public enum ECategory
{
    [Display(Name = "Electronics")]
    Electronics = 1,
   
    [Display(Name = "Clothing")]
    Clothing = 2,

    [Display(Name = "Beauty")]
    Beauty = 3,

    [Display(Name = "Food")]
    Food = 4
}
