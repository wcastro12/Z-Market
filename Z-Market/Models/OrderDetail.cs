using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Market.Models
{
   public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

   
        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Display(Name = "Descripcion")]
        [StringLength(200, ErrorMessage = "Numero de caracteres entre {1} y {2}", MinimumLength = 1)]
        public string Description { get; set; }

        [DataType(DataType.Currency)]//tipo de dato para todos los numeros
        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Range(0.1, Double.PositiveInfinity, ErrorMessage = "Valor Incorrecto")]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString ="{0:N2}",ApplyFormatInEditMode =false)]
        [DataType(DataType.Currency)]//tipo de dato para todos los numeros
        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Range(0.1, Double.PositiveInfinity, ErrorMessage = "Valor Incorrecto")]
        [Display(Name = "Precio")]
        public float Quantity { get; set; }

        public int OrderId { get; set; }
        public int ProductoId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
