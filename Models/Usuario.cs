using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; } 
        public byte[]? Foto { get; set; }
        public double? Latitude { get; set; } // programador sempre usará
        public double? Longitude { get; set; } // programador sempre usará
        public DateTime? DataAcesso { get; set; }

        [NotMapped] //DataAnnotation = Anotação de data -> Gera no começo da classe o Using System.ComponentModel.DataAnnotations.Schema;
        public string PasswordString {get; set; } = string.Empty;

        public List<Personagem> Personagens { get; set; } = new List<Personagem>();

        public string Perfil { get; set; } = string.Empty;

        public string? Email { get; set; }

















    }
}