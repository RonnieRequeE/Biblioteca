using BibliotecaBlazor.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaBlazor.Services
{
    public class LibroService
    {
        private readonly IMongoCollection<Libro> _libros;

        public LibroService(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDbSettings:ConnectionString");
            var databaseName = configuration.GetValue<string>("MongoDbSettings:DatabaseName");
            var collectionName = configuration.GetValue<string>("MongoDbSettings:BooksCollection");

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _libros = database.GetCollection<Libro>(collectionName);
        }

        public async Task<List<Libro>> GetAsync()
        {
            return await _libros.Find(l => true).ToListAsync();
        }

        public async Task<Libro?> GetByIdAsync(string id)
        {
            return await _libros.Find(l => l.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Libro libro)
        {
            libro.Estado = "Activo"; // Siempre se crea como Activo
            await _libros.InsertOneAsync(libro);
        }

        public async Task UpdateAsync(string id, Libro libroIn)
        {
            await _libros.ReplaceOneAsync(l => l.Id == id, libroIn);
        }

        // Eliminación Lógica
        public async Task DeleteLogicAsync(string id)
        {
            var filter = Builders<Libro>.Filter.Eq(l => l.Id, id);
            var update = Builders<Libro>.Update.Set(l => l.Estado, "Inactivo");
            await _libros.UpdateOneAsync(filter, update);
        }
    }
}
