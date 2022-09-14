<Query Kind="Expression" />

Albums
	.Where(x => x.ReleaseYear > 1989 && x.ReleaseYear < 2000)
	
	.Select(x => new
	{
		Year = x.ReleaseYear,
		Title = x.Title,
		Artist = x.Artist.Name,
		Label = x.ReleaseLabel 
	})
	.OrderBy(x =>x.Year) //Year is the anonymous data type deffintion,ReleaseYear is 
	.ThenBy(x => x.Title)
	
	
	
	