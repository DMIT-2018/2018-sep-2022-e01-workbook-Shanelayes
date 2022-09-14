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

//Using navigational properties and annoymous data set (collection) 
//referance student notes/ demo/ eResturaunt/ Linq:query and method syntax

//Find all albums released in the 90s (1990-1999)
//order the albums by ascending year and then alphabetically by album

//display artist name, title, year, release label

//concerns: 1. not all properties of albums are to be displayed
//			2. order of the properties are to be displayed in a differnt sequence then the definition of the properties on the entity album.
//			3. the artist name is not on the album table but is on the artist table 
// 	Solution: use an anonomous data collection 

//the anonymous data instance is defined within the select by declared fields (properties)
//the order of the defined fields on the new instance will be done in specifying the properties of the anonympous data collection 


Albums 
	.Where(x => x.ReleaseYear > 1989 && x.ReleaseYear < 2000)
	.OrderBy(x => x.ReleaseYear)
	.ThenBy(x => x.Title)
	.Select(x => new {
		Year = x.ReleaseYear, 
		Title = x.Title,
		Artist = x.Artist.Name, 
		Label = x.ReleaseLabel
	})
	
	
	