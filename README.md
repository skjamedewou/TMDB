# TMDB CLI Tool
Project URL : https://roadmap.sh/projects/tmdb-cli

A simple command-line application written in C# that uses the [TMDB API](https://www.themoviedb.org/) to fetch and display movie data in the Windows terminal.

---

#  Features

- Fetches movies by category:
  -  `playing` – Now playing in theaters
  -  `popular` – Most popular movies
  -  `top` – Top-rated movies
  -  `upcoming` – Upcoming releases
- Clean console output
- Uses HTTP + JSON (via `HttpClient` and `System.Text.Json`)
- Self-contained `.exe` publishing (no .NET installation required)

---

# ️ Requirements

- Windows 10 or later
- TMDB API key (free)
- [.NET SDK](https://dotnet.microsoft.com/download) (only required if you want to build from source)

---

#  How to Get a TMDB API Key

1. Create an account on [TMDB.org](https://www.themoviedb.org/)
2. Go to your [API settings](https://www.themoviedb.org/settings/api)
3. Request an API key (v3 auth)
4. Copy and store your key safely

---

#  Set Your API Key (Environment Variable)

Before running the app, set the `TMDB_API_KEY` environment variable.

# Run Examples
- tmdb-cli.exe --type playing
- tmdb-cli.exe --type popular
- tmdb-cli.exe --type top
- tmdb-cli.exe --type upcoming
