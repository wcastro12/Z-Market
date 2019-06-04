using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Market.Models
{
    [Table("Empleadox")]//Cambiar el nombre da la tabla en Base de datos
    public class Employee
    {
        [Key]//auto incrementadoer  y primary key
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Display(Name = "Primer Nombre", Order = 1)]//Lo que se muestra del atrubuto
        [StringLength(50, ErrorMessage = "Numero de caracteres entre {1} y {2}", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Debe ingregar {0}")]
        [Display(Name = "Apellido")]
        [StringLength(50, ErrorMessage = "Numero de caracteres entre {1} y {2}", MinimumLength = 1)]
        public string LastName { get; set; }

        [Display(Name ="Salario")]
        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode =false)]
        public decimal Salary { get; set; }

        [Display(Name ="Bono")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public float BonusPercent { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true , DataFormatString = "{0:yyyy/MM/dd}", HtmlEncode = true)]
        [Display(Name ="Fecha Nacimiento")]
        public DateTime DateofBirth { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:hh:mm}",HtmlEncode =true )]
        [Display(Name ="Horario de trabajo")]
        public DateTime StratTime { get; set; }

        [DataType(DataType.EmailAddress,ErrorMessage ="Correo incorrecto")]
        [Display(Name ="Correo electronico")]
        public string Email { get; set; }

        [Column ("link")]//modifica el nombre de la Base de dato
        [DataType(DataType.Url,ErrorMessage ="Url incorrecta")]
        [Display(Name ="URL")]
        public string URL { get; set; }
        public int DocumentTypeId { get; set; }


        [Display(Name = "Documento")]
        public string Documento { get; set; }

        //campo calculado que no se crea en la BD
        [NotMapped]
        public int Age { get { return DateTime.Now.Year - DateofBirth.Year; }  }

        public virtual DocumentType DocumentType { get; set; }
    }
}
