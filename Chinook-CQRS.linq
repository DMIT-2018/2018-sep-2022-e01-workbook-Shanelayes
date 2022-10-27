<Query Kind="Program">
  <Connection>
    <ID>c22ed120-bfce-4233-bbab-b08fac5b873b</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>SHANEPC</Server>
    <Database>Chinook</Database>
    <DisplayName>Chinook-Entity</DisplayName>
    <DriverData>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	//This is the demo for the UX/UI portion of this course.
	
	//Main will represent the web page post method 
	string searchArg = "Deep";
	string searchBy = "Artist";
	List<TrackSelection> trackList = Track_FetchTrackBy(searchArg, searchBy);
	;
	trackList.Dump();
}
#region CQRS Query
public class TrackSelection
{
	public int TrackId { get; set; }
	public string SongName { get; set; }
	public string AlbumTitle { get; set; }
	public string ArtistName { get; set; }
	public int Milliseconds { get; set; }
	public decimal Price { get; set; }
}

public class PlaylistTrackInfo
{
	public int TrackId { get; set; }
	public int TrackNumber { get; set; }
	public string SongName { get; set; }
	public int Milliseconds { get; set; }
}
#endregion
#region TrackServices Class
public List<TrackSelection> Track_FetchTracksBy(string searchArg, string searchBy)
{
	if (string.IsNullOrWhiteSpace(searchArg))
	{
		throw new ArgumentException("No search value entered.");
	}
	if (string.IsNullOrWhiteSpace(searchArg))
	{
		throw new ArgumentException("No search style entered.");
	}
	IEnumerable<TrackSelection> results = Tracks
																		.Where(track => track.Album.Artist.Name.Contains(searchArg) &&
																								   searchBy.Equals("Artist") ||
																								   track.Album.Title.Contains(searchArg) &&
																								   searchBy.Equals("Album"))
																		.Select(track => new TrackSelection
																		{
																			TrackId = track.TrackId,
																			SongName = track.Name,
																			AlbumTitle = track.Album.Title,
																			ArtistName = track.Album.Artist.Name,
																			Milliseconds = track.Milliseconds,
																			Price = track.UnitPrice
																		});
																		
																		
																		
																		
}
#endregion
// You can define other methods, fields, classes and namespaces here