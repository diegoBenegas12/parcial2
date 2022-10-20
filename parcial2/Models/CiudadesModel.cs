using System.Text.Json.Serialization;

namespace parcial2.Models
{
    public class CiudadesModel
    {
        public int Id { get; set; }
        public string? Ciudad { get; set; }
        public string? Estado { get; set; }
        [JsonIgnore]
        public virtual List<ClientesModel>? Clientes { get; set; }
    }
}
