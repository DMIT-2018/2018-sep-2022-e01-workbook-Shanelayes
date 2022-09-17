<Query Kind="Expression">
  <Connection>
    <ID>c3f77128-1408-4dbf-b6b0-22c18f930bfe</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>SHANEPC</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Aggregates
//.Count() - Counts the number of instances in the collection 
//.Sum(SumIdentifier => ...Sumdata) Sums (Totals) a numeric field (Numeric Expression) in a collection 
//.Min(x => ....) finds the minum value for a colection or field 
//.Max(x=> .....) Finds the maximum value for a collection or field 
//.Average(x=>...) Finds the average bvalue of a numeric collection or field 


//IMPORTANT******
//Aggregates wotk only on a collection of values 
//Aggregates Do not work on a single instance that is a non declared collection 

//.Sum, .Min, .Max and .Average must have atleast one record in their collection (if not there is noting to add up)

//.SUm and .Average Must work on numeric fields and the fields CANNOT be null 

//Syntax :Method 

//Collectionset.Aggregate(x => expression)
//collectionset.Select(....).Aggregate()
//collectionSet.Count() //.Countn() does not contain an expression 
// for .Sum(), .Min, Max and Average: The result is a single value 

//You can use multiple aggreagates on a single column 
// .Sum(x => expression).Min (x => expression)


//Find the average playing time (length) of tracks in our music collection 
//Thought process : 
// Average is an aggregate, Average needs a collection. 
//The tracks tabel is a collection
//What is the expression? Millisecods 

Tracks.Average (trackLength => trackLength.Milliseconds) //Eaach trackLength has multiple fields 


Tracks.Select(trackLength => trackLength.Milliseconds) .Average()//A single list of numbers


//Tracks.Average()
//Doesnt wor because its not a single list of numbers 
//The first one works because its a single list 
//Aborts because no specific field was referred to on the track record 

//List all albums of the 60s showing the title artist and various aggregates for albums containing tracks 
//For each album show the number of tracks , the total price of all tracks and the average playing length of the album tracks 

//Process: 
	//Start with Albums collection 
	//Artist name (.Artist)
	
	
	//Albums 
	//	.Where(album => album.ReleaseYear >= 1960 && album.ReleaseYear <= 1970)



	Albums
		.Where(album => album.Tracks.Count() > 0
						&& (album.ReleaseYear > 1959 && album.ReleaseYear < 1970))
		.Select(x => new {
			Title = album.Title,
			Artist = album.Artist.Name,
			NumberOfTracks = album.Tracks.Count(),
			PriceOfTracks = album.Tracks.Sum(tr=>tr.UnitPrice),
			AverageTrackLength= album.Tracks.Select(tr => tr.Milliseconds).Average()
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		