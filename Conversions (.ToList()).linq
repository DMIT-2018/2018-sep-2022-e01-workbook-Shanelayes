<Query Kind="Program">
  <Connection>
    <ID>c3f77128-1408-4dbf-b6b0-22c18f930bfe</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>SHANEPC</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Chinook</Database>
  </Connection>
  <Namespace>static UserQuery</Namespace>
</Query>

void Main()
{
	//conversions 
	//the collection we will look at is Iquerable, iEnumerable and List
	
	//Display the albums and their tracks. Display the album title
	//Artist name and album tracks. For each track show the song name 
	//and play time. show only albums with 25 or more tracks.
	
	var albumList = Albums		
							.Where(a => a.Tracks.Count >= 25)
							.Select(a => new {
							Title = a.Title,
							Artist = a.Artist.Name,
							songs = a.Tracks
								.Select(tr => new{
								song = tr.Name,
								PlayTime = tr.Milliseconds / 1000
								} )
								
							})
							.Dump();
						}

// You can define other methods, fields, classes and namespaces here

public class songItem
{
	public string Song { get;  set ; }
	public double PlayTime{get;set;}
}
public class AlbumTracks 
{
	public string Title {get; set;}
	public string Artist {get;set;}
	public List <songItem> Songs {get;set;}
}
