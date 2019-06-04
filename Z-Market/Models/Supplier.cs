using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Market.Models
{
   public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Display(Name = "Nombre", Order = 1)]
        [StringLength(50, ErrorMessage = "Numero de caracteres entre {1} y {2}", MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Display(Name = "Nombre", Order = 1)]
        [StringLength(50, ErrorMessage = "Numero de caracteres entre {1} y {2}", MinimumLength = 1)]
        public string ContacFirsName { get; set; }

        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Display(Name = "Nombre", Order = 1)]
        [StringLength(50, ErrorMessage = "Numero de caracteres entre {1} y {2}", MinimumLength = 1)]
        public string ContacLastName { get; set; }

        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Display(Name = "Nombre", Order = 1)]
        [StringLength(50, ErrorMessage = "Numero de caracteres entre {1} y {2}", MinimumLength = 1)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Display(Name = "Nombre", Order = 1)]
        [StringLength(50, ErrorMessage = "Numero de caracteres entre {1} y {2}", MinimumLength = 1)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Display(Name = "Nombre", Order = 1)]
        [StringLength(50, ErrorMessage = "Numero de caracteres entre {1} y {2}", MinimumLength = 1)]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Numero de caracteres entre {1} y {2}", MinimumLength = 1)]
        [Required(ErrorMessage ="Campo necesario")]
        [Display(Name ="Documento")]
        public string Document { get; set; }

        public virtual DocumentType DocumentType { get; set; }
        public int DocumentTypeId { get; set; }

        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
    }
}
