<Query Kind="Program">
  <Connection>
    <ID>c3f77128-1408-4dbf-b6b0-22c18f930bfe</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>SHANEPC</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	//Find the first album by deep purple
	//First gives the first record in a collection unless the collection is empty
	//used to check and see if a record existed in a BLL service method, 
	var artistParam = "Deep Purple";
	var resultFOD = Albums 
									.Where(a => a.Artist.Name.Equals(artistParam))
									.Select(a => a)
									.OrderBy(a =>a.ReleaseYear )
									.FirstOrDefault()//Adding this will display the first album. taking this out will display all albums
									//.Dump()
									;
									
									//Adding an if to stop the program from crashing 
	if(resultFOD != null)// null is the value of an object that doesnt exist. (if user enters a typo it will run the error message instead of crashing)
		{
			resultFOD.Dump();
		}	
		else
	{
		Console.WriteLine($"No albums found for artist {artistParam}");
	}
	//Distinct()
	//Removes duplicate reported lines from the records 
	//Get a list of customer countries
	var resultsDistinct = Customers
										.OrderBy(c => c.Country)
										.Select(c => c.Country)
										.Distinct()
										.Dump()
										;
						
						
	//.Take() and .Skip()
	//The query method was to return only the needed records for the display not the entire collection, 
	//1)The query was executed returning a collection of size X 
	//2) You obtained the total count of returned records 
	//3) calculated the number of records to skip(pageNumber -1) * pageSize
	//4) ON the return method statement you used  
				// return variableName.Skip(rowsSkiped).Take(pageSize).ToList()


//.Union()
//Rules in Linq are the same as SQL
//Result is the same as SQL, combine seperate collections into one
//The syntax of union (queryA).Union(queryB)[.Union(query....)]
//rules:
		//Number of columns are the same 
		//Data types must be the same and ordering should be done as a method after the last union
		
var resultsUnion = (Albums
							.Where(a => a.Tracks.Count() == 0)
							.Select(a => new
							{
								Title = a.Title,
								totalTracks = 0,
								totalCost = 0.00m,
								averageLength = 0.00d

							})
							.OrderBy(a => a.totalTracks)

							.Union(Albums
							.Where(a => a.Tracks.Count() > 0)
							.Select(a => new
							{
								Title = a.Title,
								totalTracks = a.Tracks.Count(),
								totalCost = a.Tracks.Sum(tr => tr.UnitPrice),
								averageLength = a.Tracks.Average(tr => tr.Milliseconds)
							})
							))
						
							.OrderBy(a => a.totalTracks)
							.Dump()
							
							;
}



