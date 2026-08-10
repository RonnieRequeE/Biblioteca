using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BibliotecaBlazor.Models
{
    public class Categoria
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [BsonElement("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [BsonElement("area")]
        public string Area { get; set; } = string.Empty;

        [BsonElement("nivel")]
        public string Nivel { get; set; } = string.Empty;

        [BsonElement("fechaCreacion")]
        public DateTime? FechaCreacion { get; set; }

        [BsonElement("responsable")]
        public string Responsable { get; set; } = string.Empty;

        [BsonElement("estado")]
        public string Estado { get; set; } = "Activo"; // "Activo" o "Inactivo"
    }
}
