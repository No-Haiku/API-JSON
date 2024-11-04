using App.Data; // Asegúrate de que esta referencia es correcta
using App.Models; // Asegúrate de que esta referencia es correcta
using Newtonsoft.Json; // No olvides agregar esta referencia si no está incluida
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace App.Service
{
    public class NameService : INameService
    {
        private readonly List<NameModel> _names;

        public NameService()
        {
            // Manejo de excepciones al leer el archivo
            try
            {
                var json = File.ReadAllText("Data/names.json");
                var nameResponse = JsonConvert.DeserializeObject<NameResponse>(json);
                _names = nameResponse?.Response ?? new List<NameModel>();
            }
            catch (IOException ex)
            {
                // Manejo de errores en caso de que el archivo no se pueda leer
                throw new FileNotFoundException("El archivo names.json no se encontró o no se puede leer.", ex);
            }
            catch (JsonException ex)
            {
                // Manejo de errores en caso de que el JSON sea inválido
                throw new InvalidDataException("El contenido del archivo names.json no es un JSON válido.", ex);
            }
        }

        public IEnumerable<NameModel> GetNames(string gender, string startsWith)
        {
            // Filtrar nombres y genero 
            var filteredNames = _names.AsEnumerable();

            if (!string.IsNullOrEmpty(gender))
            {
                filteredNames = filteredNames.Where(name => name.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(startsWith))
            {
                filteredNames = filteredNames.Where(name => name.Name.StartsWith(startsWith, StringComparison.OrdinalIgnoreCase));
            }

            return filteredNames.ToList();
        }
    }
}
