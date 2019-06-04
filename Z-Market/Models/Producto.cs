using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Z_Market.Common;

namespace Z_Market.Models
{
   public class Producto
    {
     
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage ="Debe ingregar {0}")]
        [Display(Name ="Nombre",Order =1)]
        [StringLength(50,ErrorMessage ="Numero de caracteres entre {1} y {2}",MinimumLength =1 )]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Display(Name = "Descripcion")]
        [StringLength(200, ErrorMessage = "Numero de caracteres entre {1} y {2}", MinimumLength = 1)]
        public string Description { get; set; }

       [DataType(DataType.Currency)]//tipo de dato para todos los numeros
        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Range(0.1,Double.PositiveInfinity,ErrorMessage ="Valor Incorrecto")]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        // [Range(typeof(DateTime),DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture), DateTime.UtcNow.ToString(""))]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}", HtmlEncode = true)]
        [ValidateYears(ErrorMessage ="Fecha fuera de rango")]
        public DateTime LastBuy { get; set; }

        [DataType(DataType.Currency)]//tipo de dato para todos los numeros
        public float Stock { get; set; }
        [StringLength(200, ErrorMessage = "Numero de caracteres entre {1} y {2}", MinimumLength = 1)]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
