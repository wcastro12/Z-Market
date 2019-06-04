using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Market.Models
{
    public class DocumentType
    {
        [Key]
        [Display(Name ="Document type")]
        public int DocumentTypeId { get; set; }

        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Display( Name ="Documento")]
        public string Description { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Custumer> Custumers { get; set; }

    }
}
