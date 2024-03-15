using System.ComponentModel.DataAnnotations;

namespace asp_practica_con_sql.Models.ViewModels
{
    public class PersonaViewModel
    {
        [Required]
        [Display(Name="Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Edad")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Genero")]
        public int GenderID { get; set; }

    }
}
