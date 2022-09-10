<Query Kind="Statements">
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

//The statement IDE (Development Envornment)
//This envornment expects the use of C# Grammer


var qSyntaxList = from arowoncollection in Albums		//Varible is created to run data through
					select arowoncollection;			//The results of the Query is not automatically displayed as in the expression envornment 
														//To Display the resukts you need to .Dump the variable holding the data result 
														// IMPORTANT .Dump() is a LinqPad method It is not a C# method 
					
				
//qSyntaxList.Dump();


//Within the statement envornment one can run all the queries in one execution 
var mSyntaxList = Albums
					.Select(arowoncollection => arowoncollection)
					//.Dump()
					;        //Method Syntax

//mSyntaxList.Dump();




var queenAlbums = Albums
				 .Where(a => a.Artist.Name.Equals("Queen"))
				 //.Dump()		After the query is run and it works you comment out the dump so it doesnt display the results of each query
				 ;
				 
				 
