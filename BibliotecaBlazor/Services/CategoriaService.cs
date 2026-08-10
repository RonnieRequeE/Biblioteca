using BibliotecaBlazor.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaBlazor.Services
{
    public class CategoriaService
    {
        private readonly IMongoCollection<Categoria> _categorias;

        public CategoriaService(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDbSettings:ConnectionString");
            var databaseName = configuration.GetValue<string>("MongoDbSettings:DatabaseName");
            var collectionName = configuration.GetValue<string>("MongoDbSettings:CategoriesCollection");

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _categorias = database.GetCollection<Categoria>(collectionName);
        }

        public async Task<List<Categoria>> GetAsync()
        {
            return await _categorias.Find(c => true).ToListAsync();
        }

        public async Task<Categoria?> GetByIdAsync(string id)
        {
            return await _categorias.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Categoria categoria)
        {
            categoria.Estado = "Activo"; // Siempre se crea como Activo
            await _categorias.InsertOneAsync(categoria);
        }

        public async Task UpdateAsync(string id, Categoria categoriaIn)
        {
            await _categorias.ReplaceOneAsync(c => c.Id == id, categoriaIn);
        }

        // Eliminación Lógica
        public async Task DeleteLogicAsync(string id)
        {
            var filter = Builders<Categoria>.Filter.Eq(c => c.Id, id);
            var update = Builders<Categoria>.Update.Set(c => c.Estado, "Inactivo");
            await _categorias.UpdateOneAsync(filter, update);
        }
    }
}
