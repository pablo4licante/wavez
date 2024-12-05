using WavezGen.ApplicationCore.EN.Wavez;
using WebWavez.Models;

namespace WebWavez.Assemblers
{
    public class UsuarioAssembler
    {

        public UsuarioViewModel ConvertirENToViewModel(UsuarioEN usuario)
        {
            UsuarioViewModel uvm = new UsuarioViewModel();
            uvm.Usuario = usuario.Usuario;
            uvm.Nombre = usuario.Nombre;
            uvm.Password = usuario.Contrasenya;
            uvm.Email = usuario.Email;
            uvm.FotoPerfil = usuario.FotoPerfil;
            return uvm;
        }

        public IList<UsuarioViewModel> ConvertirListENToListViewModel(IList<UsuarioEN> usuarios)
        {
            IList<UsuarioViewModel> uvms = new List<UsuarioViewModel>();
            foreach (UsuarioEN usuario in usuarios)
            {
                uvms.Add(ConvertirENToViewModel(usuario));
            }
            return uvms.ToList();
        }
    }
}
