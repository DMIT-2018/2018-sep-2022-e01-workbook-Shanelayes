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
	//Problem 
	//one needs to habe processed inforation from a collection to use the same collection
	//solution to this problem is to use multiple queries 
	//the early query(S) will produce the needed information/criteria to execute against the same collection in a later query(S)
	//we need to do some preprocessing 
	
	
	
	//Were doing a query to get some information then using that query to get some information from that query
	
	//Query one will generate data to be used in Query 2
	
	//Display the employees that have the most customers to suport, 
	//Dipslay the employee name and number of customers that employee supports 
	
	//What IS NOT wanted : a list of employees sorted by number of custmers supported
	//One could create a list of all employees with the customer support count ordered  decending by support count 
	
	//Information needed:
		//Maximum number of customers an employee is supporting MnC
		//compare that piece of data to all employees
		
		//A) get a list of the employees and the count of the customers each supports 
		//B) from that list we can obtain the largest count 
		//C) using the number review all the employees and their counts reporting only the employees with most customers 
		
		var  preprocessEmployeeList = Employees
															.Select(employee => new {
																Name = employee.FirstName +""+ employee.LastName,
																CustomerCount = employee.SupportRepCustomers.Count()
															})
															.Dump()
															;
															
		var highCount = preprocessEmployeeList
								.Max(maxCount => maxCount.CustomerCount)
								.Dump()
								;
			var busyEmployees = preprocessEmployeeList
											.Where(busyEmployee => busyEmployee.CustomerCount == highCount)
											.Dump()
											;


	//This is going to be used for question 5 in excercise 1, use the Query the Query shown above



}

// You can define other methods, fields, classes and namespaces here