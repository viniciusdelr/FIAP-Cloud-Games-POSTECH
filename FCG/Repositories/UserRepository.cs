using FCG.Model;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FCG.Repositories
{
    public class UsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioRepository(FCG.Connection.MongoDBContext context)
        {
            _usuarios = context.Usuarios;
        }

        public async Task<Usuario> GetUsuarioAsync(string username, string password)
        {
            return await _usuarios
                .Find(u => u.Username == username && u.Password == password)
                .FirstOrDefaultAsync();
        }

        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            await _usuarios.InsertOneAsync(usuario);
        }
    }
}
