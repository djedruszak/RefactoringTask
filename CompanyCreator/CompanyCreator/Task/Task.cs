namespace CompanyCreator.Task;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? StreetName { get; private set; }
    public string? City { get; private set; }
    public string? PostalCode { get; private set; }
    public string? Region { get; private set; }
    public string? Country { get; private set; }

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    public void AssignAddress(string streetName, string city, string postalCode, string region, string country)
    {
        this.StreetName = streetName;
        this.City = city;
        this.PostalCode = postalCode;
        this.Region = region;
        this.Country = country;
    }
}

public class Employee : Person
{
    public const int HR = 0;
    public const int ContentWriter = 1;
    public const int Standard = 2;

    public int Id { get; set; }
    public double MonthlySalary { get; private set; }
    public int Type { get; private set; }

    public Employee(int id, string firstName, string lastName, int type, double monthlySalary) : base(firstName, lastName)
    {
        Id = id;
        Type = type;
        MonthlySalary = monthlySalary;
    }

    public double GetMonthlyBonus()
    {
        if (Type == ContentWriter)
        {
            return MonthlySalary * 0.05;
        }
        else if (Type == HR)
        {
            return MonthlySalary * 0.1;
        }
        else
        {
            return MonthlySalary * 0.15;
        }
    }
}

public class Company
{
    public string Name { get; set; }
    public string? StreetName { get; private set; }
    public string? City { get; private set; }
    public string? PostalCode { get; private set; }
    public string? Region { get; private set; }
    public string? Country { get; private set; }

    public IRepository Repository { get; set; }
    public List<Employee> Employees { get; private set; }
    
    private object guard = new object();

    public Company(string name)
    {
        Name = name;
    }
    
    public void AssignAddress(string streetName, string city, string postalCode, string region, string country)
    {
        this.StreetName = streetName;
        this.City = city;
        this.PostalCode = postalCode;
        this.Region = region;
        this.Country = country;
    }

    public void AddEmployee(int id, string firstName, string lastName, int type, double monthlySalary, string streetName, string city, string postalCode,
        string region, string country)
    {
        Employee employee = new Employee(id, firstName, lastName, type, monthlySalary);
        employee.AssignAddress(streetName, city, postalCode, region, country);
        Employees.Add(employee);
    }

    public async void SaveEmployees(List<Employee> employees)
    {
        lock (guard)
        {
            await Repository.SaveEmployees(employees);
        }
    }

    public void UpdateEmployeeSalary(int id, double salary)
    {
        Employee employee;
        for (int i = 0; i < Employees.Count; i++)
        {
            if (Employees[i].Id == id)
            {
                employee = Employees[i];
                break;
            }
        }

        employee.MonthlySalary = salary;
    }
}