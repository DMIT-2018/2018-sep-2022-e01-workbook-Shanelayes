<Query Kind="Program">
  <Connection>
    <ID>ef024a3c-6298-4433-8aca-a7b6b4880f43</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Server>WC320-07\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	var results = Employees
		.Where(employee => employee.Title.Contains("Sales Support"))
		.Select(employee => new Employee {
			FullName = employee.LastName + ", " + employee.FirstName,
			Title = employee.Title,
			Phone = employee.Phone,
			//CustomerList = CustomerByEmployee(employee.EmployeeId)
			CustomerList = employee.SupportRepCustomers
				.Select(customer => new Customer {
					FullName = customer.LastName + ", " + customer.FirstName,
					City = customer.City,
					State = customer.State
				})
				.ToList()
	});
	
	results.Dump();
}

//Nested queries (query within a query...)
//Sometimes referred to as subqueries 

//List all sales support employees showing their fullname (last, first), title, and phone
//For each employee, show a list of customers they support.
//	Show the customer fullname (last, first), city, and state

//Employee1, title, phone
//	Customer200, city, state
//	Customer236, city, state
//	Customer946, city, state
//Employee2, title, phone
//	Customer945, city, state
//	Customer345, city, state
//...

//There appears to be 2 seperate lists that need to be within one final dataset collection
//	List of employees
//	List of customers
//Concern: The lists are intermixed

//C# point of view in a class definition
//First: this is a composite class. The class is describing an employee.
//	Each instance of the employee with have a list of employee customers

//class EmployeeList
//	fullname (property)
//	title (property)
//	phone (property)
//	collection of customers (property: List<T>)



public class Employee {
	public string FullName {get; set;}
	public string Title {get; set;}
	public string Phone {get; set;}
	public List<Customer> CustomerList {get; set;}
}

public class Customer {
	public string FullName {get; set;}
	public string City {get; set;}
	public string State {get; set;}
}

/*
//Don't need this. Refer to example in main
List<Customer> CustomerByEmployee(int employeeId) {
	var customerList = Customers
		.Where(customer => customer.SupportRep.EmployeeId == employeeId)
		.Select(customer => new Customer
		{
			FullName = customer.LastName + ", " + customer.FirstName,
			City = customer.City,
			State = customer.State
		})
	;
	return customerList.ToList();
}
*/