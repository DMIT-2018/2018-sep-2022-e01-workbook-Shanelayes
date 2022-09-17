<Query Kind="Statements">
  <Connection>
    <ID>c3f77128-1408-4dbf-b6b0-22c18f930bfe</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>SHANEPC</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Chinook</Database>
  </Connection>
</Query>

//List all albums that are from 1990. 
//Display the album title, and artist name 
//for each album disply its tracks 


var albumTracks = Albums
	.Where(album => album.ReleaseYear == 1990)
	.Select (album => new {
		Title = album.Title,
		Artist = album.Artist.Name,
		Tracks = album.Tracks
				.Select(trackName => new {
					song = trackName.Name,
					genre = trackName.Genre.Name
					})
	})
	.Dump()
	;
	
