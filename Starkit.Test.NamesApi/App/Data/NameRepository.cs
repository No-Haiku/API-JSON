using App.Models;
using System.Text.Json;

namespace App.Data
{
    public class NameRepository
    {
        private readonly List<NameModel> _names;

        public NameRepository()
        {
            var jsonData = File.ReadAllText("path_to_json/names.json");
            _names = JsonSerializer.Deserialize<List<NameModel>>(jsonData);
        }

        public IEnumerable<NameModel> GetNames(string gender = null, string nameStartsWith = null)
        {
            return _names.Where(n =>
                (string.IsNullOrEmpty(gender) || n.Gender == gender) &&
                (string.IsNullOrEmpty(nameStartsWith) || n.Name.StartsWith(nameStartsWith, StringComparison.OrdinalIgnoreCase))
            );
        }
    }

}
