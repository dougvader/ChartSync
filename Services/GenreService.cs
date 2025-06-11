using System;
using System.Collections.Generic;
using System.Linq;

namespace ChartSync.Services
{
    public class GenreService
    {
        public List<Genre> Genres { get; private set; } = new();
        public event Action? OnChange;

        public void BuildGenres(IEnumerable<string> allCharts)
        {
            // Take text before “Beatport” as genre name
            var list = allCharts
                .Select(name => {
                    var parts = name.Split("Beatport")[0].Trim();
                    return new Genre
                    {
                        Name = parts,
                        Slug = parts.ToLowerInvariant().Replace(" ", "-")
                    };
                })
                .GroupBy(g => g.Slug)
                .Select(g => g.First())
                .ToList();

            // Assign rotating colors
            var palette = new[] { "#19cb98", "#1da1f2", "#ffb429", "#e11d48", "#7c3aed" };
            for (int i = 0; i < list.Count; i++)
                list[i].Color = palette[i % palette.Length];

            Genres = list;
            OnChange?.Invoke();
        }

        public Genre? SelectedGenre { get; private set; }
        public void SetSelectedGenre(Genre genre)
        {
            SelectedGenre = genre;
            OnChange?.Invoke();
        }
    }

    public class Genre
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Color { get; set; } = "#444";
    }
}
