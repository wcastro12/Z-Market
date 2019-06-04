using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Market.Models
{
    public class ProductOrder:Producto
    {

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]//tipo de dato para todos los numeros
        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Range(0.1, Double.PositiveInfinity, ErrorMessage = "Valor Incorrecto")]
        [Display(Name = "Cantidad")]
        public float Quantity { get; set; }

        public decimal Value { get { return Price * (decimal)this.Quantity; }  }
    }
}
