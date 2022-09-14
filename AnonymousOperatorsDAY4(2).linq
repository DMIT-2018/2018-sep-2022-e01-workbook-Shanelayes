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

//List all albums with labels. Any album with no labels should be indicated as unknown
//List title,Label and ArtisName

//Understand the problem

//Collection: Albums 
//Slective Data: Anonymous data set
//Label (nullable): Either unkown or LabelName 

//Design of Query
//Albums 
//Select( New{})
//Fields will be title, label, artist.Name

//label ???? ternary operator (condition(s) ? true value: false Value)


//Coding and testing 



Albums
	.OrderBy(x => x.ReleaseLabel)
	.Select(x => new{
		Title= x.Title,
		Label = x.ReleaseLabel == null ? "Unknown": x.ReleaseLabel,
		Artist = x.Artist.Name 
	})
