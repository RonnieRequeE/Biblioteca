using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BibliotecaBlazor.Models
{
    public class Libro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [BsonElement("autor")]
        public string Autor { get; set; } = string.Empty; // Guardará el Nombre Completo o ID del Autor de forma simple

        [BsonElement("categoria")]
        public string Categoria { get; set; } = string.Empty; // Guardará el Nombre o ID de la Categoría de forma simple

        [BsonElement("anioPublicacion")]
        public int AnioPublicacion { get; set; }

        [BsonElement("editorial")]
        public string Editorial { get; set; } = string.Empty;

        [BsonElement("estado")]
        public string Estado { get; set; } = "Activo"; // "Activo" o "Inactivo"
    }
}
