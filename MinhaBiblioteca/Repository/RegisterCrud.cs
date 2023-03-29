using Microsoft.EntityFrameworkCore;
using MinhaBiblioteca.Models;
using WebApplication1.data;

namespace MinhaBiblioteca.Repository
{
    public class RegisterCrud : IRegisterCrud
    {
            public readonly database _context;

            public RegisterCrud(database context)
            {
                _context = context;
            }
            public async Task<RegisterModel> Create(RegisterModel register)
            {
                _context.registrar.Add(register);
                await _context.SaveChangesAsync();

                return register;
            }
            public async Task<IEnumerable<RegisterModel>> Get()
            {
                return await _context.registrar.ToListAsync();
            }

            public async Task<RegisterModel> GetId(int id)
            {
                return await _context.registrar.FindAsync(id);
            }
    }
}
