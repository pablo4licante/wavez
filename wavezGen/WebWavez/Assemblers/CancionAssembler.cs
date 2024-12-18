using WavezGen.ApplicationCore.EN.Wavez;
using WebWavez.Models;

namespace WebWavez.Assemblers
{
    public class CancionAssembler
    {

        public CancionViewModel CovertirENToViewModel(CancionEN cancion)
        {
            CancionViewModel cvm = new CancionViewModel();
            cvm.Id = cancion.Id;
            cvm.Titulo = cancion.Titulo;
            cvm.Genero = cancion.Genero;
            cvm.FotoPortada = cancion.FotoPortada;
            if(cancion.Fecha != null)
            {
                cvm.Fecha = (DateTime)cancion.Fecha;
            }
            cvm.numReproducciones = cancion.NumReproducciones;
            cvm.Autor = cancion.Autor.Usuario;
            cvm.AutorDisplay = cancion.Autor.Nombre;
            cvm.Url = cancion.Url;
            return cvm;
        }

        public IList<CancionViewModel> ConvertirListENToListViewModel(IList<CancionEN> canciones)
        {
            IList<CancionViewModel> cvms = new List<CancionViewModel>();
            foreach (CancionEN cancion in canciones)
            {
                cvms.Add(CovertirENToViewModel(cancion));
            }
            return cvms.ToList();
        }
    }
}
