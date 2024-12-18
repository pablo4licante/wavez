using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace WebWavez.Models
{

    public class UsuarioViewModel
    {
        [ScaffoldColumn(false)]

        public string Usuario { get; set; }

        public string Nombre { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FotoPerfil { get; set; }
        public bool EsSeguidoPorUsuarioActual { get; set; }


    }

    public class PerfilViewModel
    {
        public UsuarioViewModel Usuario { get; set; }  
        public IEnumerable<CancionViewModel> Canciones { get; set; }
        public IEnumerable<PlaylistViewModel> Playlists { get; set; }
        public IEnumerable<UsuarioViewModel> Seguidores { get; set; }
        public IEnumerable<UsuarioViewModel> Seguidos { get; set; }
        public bool EsPerfilPropio { get; set; }
    }

    public class LoginUsuarioViewModel
    {
        [Display(Prompt = "Introduce el nombre de usuario", Description = "Nombre de usuario de Usuario", Name = "Usuario *")]
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string Usuario { get; set; }

        [Display(Prompt = "Introduce la contraseña", Description = "Password del Usuario", Name = "Password *")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }

    }


    public class RegistroUsuarioViewModel
    {
        [Display(Prompt = "Introduce el nombre de usuario", Description = "Nombre de usuario de Usuario", Name = "Usuario *")]
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string Usuario { get; set; }

        [Display(Prompt = "Introduce tu nombre", Description = "Nombre del Usuario", Name = "Nombre *")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Display(Prompt = "Introduce la contraseña", Description = "Password del Usuario", Name = "Password *")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }

        [Display(Prompt = "Confirma la contraseña", Description = "Confirmar la password del Usuario", Name = "Confirmar *")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Repetir la contraseña es obligatorio")]
        public string ConfirmPassword { get; set; }

        [Display(Prompt = "Introduce el email", Description = "Email del Usuario", Name = "Email *")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }

        [Display(Prompt = "Introduce tu foto de perfil", Description = "Foto de perfil del Usuario", Name = "Foto *")]
        public string FotoPerfil { get; set; }

        public IFormFile FicheroFotoPortada { get; set; }
    }

}
