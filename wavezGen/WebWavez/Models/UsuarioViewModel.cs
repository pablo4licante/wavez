using System.ComponentModel.DataAnnotations;

namespace WebWavez.Models
{
    public class UsuarioViewModel
    {
        [ScaffoldColumn(false)]
        public string Usuario { get; set; }

        [Display(Prompt = "Nombre del usuario", Description = "Nombre del usuario", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el usuario")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre del usuario no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Contraseña del usuario", Description = "Contraseña del usuario", Name = "Contraseña")]
        [Required(ErrorMessage = "Debe indicar una contraseña para el usuario")]
        [StringLength(maximumLength: 50, ErrorMessage = "La contraseña del usuario no puede tener más de 50 caracteres")]
        public string Contrasenya { get; set; }

        [Display(Prompt = "Email del usuario", Description = "Email del usuario", Name = "Email")]
        [Required(ErrorMessage = "Debe indicar un email para el usuario")]
        [EmailAddress(ErrorMessage = "Debe ser una dirección de email válida")]
        public string Email { get; set; }

        public string FotoPerfil { get; set; }
    }
}