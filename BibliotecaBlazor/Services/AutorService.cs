using BibliotecaBlazor.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaBlazor.Services
{
    public class AutorService
    {
        private readonly IMongoCollection<Autor> _autores;

        public AutorService(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDbSettings:ConnectionString");
            var databaseName = configuration.GetValue<string>("MongoDbSettings:DatabaseName");
            var collectionName = configuration.GetValue<string>("MongoDbSettings:AuthorsCollection");

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _autores = database.GetCollection<Autor>(collectionName);
        }

        public async Task<List<Autor>> GetAsync()
        {
            return await _autores.Find(a => true).ToListAsync();
        }

        public async Task<Autor?> GetByIdAsync(string id)
        {
            return await _autores.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Autor autor)
        {
            autor.Estado = "Activo"; // Siempre se crea como Activo
            await _autores.InsertOneAsync(autor);
        }

        public async Task UpdateAsync(string id, Autor autorIn)
        {
            await _autores.ReplaceOneAsync(a => a.Id == id, autorIn);
        }

        // Eliminación Lógica
        public async Task DeleteLogicAsync(string id)
        {
            var filter = Builders<Autor>.Filter.Eq(a => a.Id, id);
            var update = Builders<Autor>.Update.Set(a => a.Estado, "Inactivo");
            await _autores.UpdateOneAsync(filter, update);
        }
    }
}
