using MinhaBiblioteca.Models;

namespace MinhaBiblioteca.Repository
{
    public interface IRegisterCrud
    {
           
            Task<RegisterModel> Create(RegisterModel register);
            Task<IEnumerable<RegisterModel>> Get();
    }
}
