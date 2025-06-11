using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChartSync.Services
{
    public class ChartService
    {
        private readonly HttpClient _http;
        public List<string> AllCharts { get; private set; } = new();
        public string SelectedChart { get; private set; } = "";

        public event Action? OnChange;

        public ChartService(HttpClient http) => _http = http;

        public async Task LoadChartsAsync()
        {
            var raw = await _http.GetStringAsync("data/BP_genres_fancy.txt");
            AllCharts = raw
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim().Trim('"'))
                .Distinct()
                .ToList();
        }

        // Called by your dropdown
        public void SetSelectedChart(string chart)
        {
            SelectedChart = chart;
            OnChange?.Invoke();
        }
    }
}
