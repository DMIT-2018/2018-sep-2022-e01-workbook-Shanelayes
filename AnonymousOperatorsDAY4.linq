<Query Kind="Expression">
  <Connection>
    <ID>64990220-1294-422c-b402-16e09bdda722</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>SHANEPC</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Chinook</Database>
  </Connection>
</Query>

//List all albums showing the title, artist, name, year and decade of the release using oldies, 70s, 80s, 90s, or moderen.
//OrderBy Decade


Albums 
	.Select (x => new {
		Title = x.Title,
		Artist = x.Artist.Name,
		Year = x.ReleaseYear,
		Decade = x.ReleaseYear < 1970 ? "Oldies" :
				 x.ReleaseYear < 1980 ? "70s" :
				 x.ReleaseYear < 1990 ? "80s":
				 x.ReleaseYear < 2000 ? "90s" : "Modern"
	})
	.OrderBy(x => x.Year)