namespace CompanyCreator;

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
    
    public double MonthlySalary { get; private set; }
    public int Type { get; private set; }

    public Employee(string firstName, string lastName, int type, double monthlySalary) : base(firstName, lastName)
    {
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

    public List<Employee> Employees { get; private set; }

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

    public void AddEmployee(string firstName, string lastName, int type, double monthlySalary, string streetName, string city, string postalCode,
        string region, string country)
    {
        Employee employee = new Employee(firstName, lastName, type, monthlySalary);
        employee.AssignAddress(streetName, city, postalCode, region, country);
        Employees.Add(employee);
    }
}