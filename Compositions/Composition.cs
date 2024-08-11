using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace Compositions
{
    public class Composition
    {
        private const string FilePath = "film.json";

        public List<Music> GetFilms()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Music>();
            }

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Music>>(json);
        }

        public void SaveFilms(List<Music> films)
        {
            var json = JsonSerializer.Serialize(films);
            File.WriteAllText(FilePath, json);
        }
    }
}
