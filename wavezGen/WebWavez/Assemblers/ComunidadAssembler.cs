using WavezGen.ApplicationCore.EN.Wavez;
using WebWavez.Models;

namespace WebWavez.Assemblers
{
    public class ComunidadAssembler
    {
        public ComunidadViewModel CovertirENToViewModel(ComunidadEN comunidad)
        {
            ComunidadViewModel cvm = new ComunidadViewModel();
            cvm.Genero = comunidad.Genero;
            return cvm;
        }

        public IList<ComunidadViewModel> ConvertirListENToListViewModel(IList<ComunidadEN> comunidades)
        {
            IList<ComunidadViewModel> cvms = new List<ComunidadViewModel>();
            foreach (ComunidadEN comunidad in comunidades)
            {
                cvms.Add(CovertirENToViewModel(comunidad));
            }
            return cvms.ToList();
        }
    }
}
