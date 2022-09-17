<Query Kind="Program">
  <Connection>
    <ID>ef024a3c-6298-4433-8aca-a7b6b4880f43</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>WC320-07\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Strongly typed dataset within program IDE
void Main() {
	//Find songs by partial song name
	//Display album title, song, artist name
	//Order by song
	
	/*
	//Refer to SongsByPartialName method for code
	var songCollection = Tracks
							.Where(track => track.Name.Contains("dance"))
							.OrderBy(track => track.Name)
							//Making it a class now dumps IOrderedQueryable with <SongList>
							.Select(track => new SongList
							{
								Album = track.Album.Title,
								Song = track.Name,
								Artist = track.Album.Artist.Name
								//Must match with the variable names of class
								//ArtistName = track.Album.Artist.Name
							})
	;
	*/
	
	//Pretend that the Main() is the web page
	//Assume a value was entered into a web page
	//Assume that a post button was pressed
	//Assume Main() is the OnPost event
	
	string inputValue = "dance";
	List<SongList> songCollection = SongsByPartialName(inputValue);
	songCollection.Dump(); //Assume is the web page display
}
//You can define other methods, fields, classes, and namespaces here

//C# really enjoys strongly typed data fields, whether these fields are primitive data types (int, double, etc..)
// Or developer define datatypes (classes)

public class SongList {
	public string Album {get; set;}
	public string Song {get; set;}
	public string Artist {get; set;}
}

//Imagine the following method exists in a service in your BLL
//This method receives the web page parameter value for the query
//This method will need to return a collection

List<SongList> SongsByPartialName(string partialSongName) {
	//If var does not work, change to IEnumerable<SongList>
	//IQueryable is data from SQL, IEnumerable is data from execution
	var songCollection = Tracks
							.Where(track => track.Name.Contains(partialSongName))
							.OrderBy(track => track.Name)
							.Select(track => new SongList
							{
								Album = track.Album.Title,
								Song = track.Name,
								Artist = track.Album.Artist.Name
							})
	;
	return songCollection.ToList(); //ToList() because it produces an IEnumerable
}