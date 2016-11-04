using Diamond.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Repository.Repository
{
    public class AuthenticationRepository : IDisposable
    {
        private DiamondContext _context;

        public AuthenticationRepository()
        {
            _context = new DiamondContext();
        }

        public Usuario FindUser(string username, string password)
        {
            Usuario user = _context.Usuarios
                .Where(u => u.Login == username && u.Senha == password)
                .FirstOrDefault();

            return user;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
