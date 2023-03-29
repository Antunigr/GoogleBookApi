using MinhaBiblioteca.Models;

namespace MinhaBiblioteca.Repository
{
    public interface IRegisterCrud
    {
            Task<IEnumerable<RegisterModel>> Get();

            Task<RegisterModel> GetId(int Id);

            Task<RegisterModel> Create(RegisterModel register);

}
}
