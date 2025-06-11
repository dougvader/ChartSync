public class GenreService
{
    public string? SelectedChart { get; private set; }
    public event Action? OnChange;

    public void SetSelectedChart(string chart)
    {
        SelectedChart = chart;
        OnChange?.Invoke();
    }
    public class Genre
    {
        public string Name { get; set; } = default!;
        public string Slug { get; set; } = default!;
        public string Color { get; set; } = default!;
    }

}
