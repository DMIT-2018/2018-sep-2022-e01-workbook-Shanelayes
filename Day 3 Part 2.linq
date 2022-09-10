<Query Kind="Expression">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c12aaaaa</ID>
    <NamingService>2</NamingService>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\ChinookDemoDb.sqlite</AttachFileName>
    <DisplayName>Demo database (SQLite)</DisplayName>
    <DriverData>
      <PreserveNumeric1>true</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.Sqlite</EFProvider>
      <MapSQLiteDateTimes>true</MapSQLiteDateTimes>
      <MapSQLiteBooleans>true</MapSQLiteBooleans>
    </DriverData>
  </Connection>
</Query>

//Sorting 

//There is a signifcant differance between querry syntax and Method syntax 

//Querry syntax is much like SQL. 
//orderby field {[ascending] || [Descending]} [,field....]

//ascending is the defaulkt 

//method syntax is a series of individual methods 
//.Orderby(x => x.field) 			**First Field only***
//.OrderByDescending(x=>x.field)	**First Field only***
//.ThenBy(x=>x.field)				**Each following field**
//.ThenByDescending(x=>x.feild)		**Each following field**


//find all tracks for albyum queen order track by track names alphabetically
from x in Tracks
where x.Album.Artist.Name.Contains("Queen")
orderby x.AlbumId, x.Name
select x

	Tracks		//Navigational property
		.Where(Track => Track.Album.Artist.Name.Contains("Queen"))
		.OrderBy(Track => Track.AlbumId)
		.ThenBy(Track => Track.Name)



	Tracks      //Navigational property
		.Where(Track => Track.Album.Artist.Name.Contains("Queen"))
		.OrderBy(Track => Track.Album.Title)		//Ordered by album title instead
		.ThenBy(Track => Track.Name)