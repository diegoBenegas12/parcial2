using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace parcial2.Models
{
    public class ClientesModel
    {
        public int Id { get; set; }
        public int IdCiudad { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Documento { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FechaNacimiento { get; set; }
        public string? Ciudad { get; set; }
        public string? Nacionalidad { get; set; }

        [ForeignKey("IdCiudad")]
        public CiudadesModel? Ciudades { get; set; }
    }
}
