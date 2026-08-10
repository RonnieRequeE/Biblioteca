using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BibliotecaBlazor.Models
{
    public class Autor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [BsonElement("apellido")]
        public string Apellido { get; set; } = string.Empty;

        [BsonElement("nacionalidad")]
        public string Nacionalidad { get; set; } = string.Empty;

        [BsonElement("fechaNacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [BsonElement("genero")]
        public string Genero { get; set; } = string.Empty;

        [BsonElement("biografia")]
        public string Biografia { get; set; } = string.Empty;

        [BsonElement("estado")]
        public string Estado { get; set; } = "Activo"; // "Activo" o "Inactivo"
    }
}
