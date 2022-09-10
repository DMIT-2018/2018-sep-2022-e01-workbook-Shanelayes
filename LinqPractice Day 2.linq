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

Albums

//Quert syntax to list all records in an entity (table, collection
from arowoncollection in Albums
select arowoncollection

//Method syntax to list all records in an entity
Albums
	.Select (arowoncollection => arowoncollection ) 	//C# when using method syntax because c# is case sensitve
	
	
//Where clause
//Filter Method
//The conditions are setup the same as C#
//Beware that linqpad maynot like some C# syntax (DateTime)
//Beware that linq is converted to SQL which may not like certain c# syntax because SQL could not convert. 

//syntax
//notice the method syntax makes use of the Lambda expression
//Lambda is common when performing linq with the method syntax
//.Where(lambda expression)
//.Where( X=> condition [logical operator **&& and ||** condition2...])
//.Where(x => Bytes > 350000)
	
	
	
Tracks 
	.Where(x =>x.Bytes > 700000000)
	
	
//Query Syntax
from x in Tracks 
where x.Bytes > 700000000
select x


//Find all albums of artist queen
//The artist name is in another table
//in Sql select you would use an inner join, In linq you do not need to specify your inner join, Instead use the navigational propeties of your entity
//to generate the relationship

Albums
	.Where(a =>a.Artist.Name.Equals("Queen"))
















