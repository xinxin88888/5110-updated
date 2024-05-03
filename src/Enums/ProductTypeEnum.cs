using System.ComponentModel.DataAnnotations;
using System;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Defines an enum for the different types
    /// </summary>
    public enum ProductTypeEnum
    {
        // Adding categories for ProductType list displayed on update page for admin to choose from
        [Display(Name = "Undefined")] Undefined = 0,
        [Display(Name = "Scary")] Scary = 1,
        [Display(Name = "Kids")] Kids = 2,
        [Display(Name = "Princess")] Princess = 3,

    }
}


