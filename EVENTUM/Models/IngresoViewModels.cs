namespace EVENTUM.Models
{
    using System.ComponentModel.DataAnnotations;

    public class IngresoViewModels
    {
        [Required(ErrorMessage = "La identificación es requerida")]
        [Display(Name = "Usuario")]
        public string Login { get; set; }
        public string tipo_identificacion { get; set; }
    }

    public class IngresoClaveViewModel
    {
        [Display(Name = "Usuario")]
        public string Login { get; set; }

        [Required(ErrorMessage = "La Contraseña es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        public string tipo_identificacion { get; set; }
    }
}