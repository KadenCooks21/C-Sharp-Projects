using System.Text.RegularExpressions;
namespace ChinookLibrary.Models;

public static class DbUtility
{
    // i
    public static List<string> getGenres()
    {
        using var db = new ChinookContext();

        var results =
            from gen in db.Genres
            orderby gen.Name
            select gen.Name;

        if (!results.Any())
        {
            var list = new List<string>();
            list.Add("No Genres Found");
            return list;
        }

        return results.ToList();
    }

    // ii
    public static List<string> getArtists()
    {
        using var db = new ChinookContext();

        var results =
            from artist in db.Artists
            orderby artist.Name
            select artist.Name;

        if (!results.Any())
        {
            var list = new List<string>();
            list.Add("No Artists Found");
            return list;
        }

        return results.ToList();
    }

    /*public static List<string> getTracksFromGenre(string genre)
    {
        if (genre == null) return null;
        return getTracksFromGenre();
    }*/

    // iii
    public static List<string> getTracksFromGenre(string genre)
    {
        if (genre == null) return null;
        using var db = new ChinookContext();

        var results =
            from gen in db.Genres
            where gen.Name == genre
            select gen.GenreId;
        
        if (!results.Any())
        {
            var list = new List<string>();
            list.Add($"{genre} Not Found");
            return list;
        }

        var genreId = results.First();
        
        var songs =
            from track in db.Tracks
            where track.GenreId == genreId
            select track;

        var artists =
            from track in songs
            from artist in db.Artists
            where track.Album.ArtistId == artist.ArtistId
            select $"{track.Name}, {artist.Name}, {track.UnitPrice}";

        if (!songs.Any())
        {
            var list = new List<string>();
            list.Add($"No Tracks Found In {genre}");
            return list;
        }

        return artists.ToList();
    }

    // iv
    public static List<string> getTracksFromArtist(string artist)
    {
        if (artist == null) return null;
        using var db = new ChinookContext();
        var results =
            from art in db.Artists
            where art.Name == artist
            select art.ArtistId;
        
        if (!results.Any())
        {
            var list = new List<string>();
            list.Add($"{artist} Not Found");
            return list;
        }

        var band = results.First();
        
        var songs =
            from track in db.Tracks
            where track.Album.ArtistId == band
            select $"{track.Name}, {track.UnitPrice}";

        if (!songs.Any())
        {
            var list = new List<string>();
            list.Add($"No Tracks Found From {artist}");
            return list;
        }

        return songs.ToList();
    }

    // v
    public static List<string> getArtistSongCount()
    {
        using var db = new ChinookContext();

        var ComposerList = db.Tracks
            .Where(tracks => tracks.Composer != null) // looks for composers that aren't null
            .GroupBy(tracks => tracks.Composer) // groups by composer and filters out repeats
            .Select(group => $"{group.Key}: {group.Count()}")// selects those composers and counts their song count
            .ToList(); // puts this in a list

        return ComposerList; // returns said list
    }
    
    public static List<string> getComposers()
    {
        using var db = new ChinookContext();

        var ComposerList = db.Tracks
            .Where(tracks => tracks.Composer != null) // looks for composers that aren't null
            .GroupBy(tracks => tracks.Composer) // groups by composer and filters out repeats
            .Select(group => $"{group.Key}")// selects those composers and counts their song count
            .ToList(); // puts this in a list

        return ComposerList; // returns said list
    }
}