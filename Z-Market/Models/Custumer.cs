using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Market.Models
{
    public class Custumer
    {

        [Key]
        public int CustumerId { get; set; }
        public string Name { get; set; }
        public string ContacFirsName { get; set; }
        public string ContacLastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public string FullName { get { return string.Format(" {0} {1}", this.ContacFirsName, this.ContacLastName); } }

        public int DocumentTypeId { get; set; }

        [Display(Name = "Documento")]
        public string Document { get; set; }

        public virtual DocumentType DocumentType { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
