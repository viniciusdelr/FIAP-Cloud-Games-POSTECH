using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FCG.Model
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("username")]
        public string? Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$",
            ErrorMessage = "A senha deve conter letras, números e caracteres especiais.")]
        public string Password { get; set; }
    }
}
