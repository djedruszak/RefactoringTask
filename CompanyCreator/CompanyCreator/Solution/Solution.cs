namespace CompanyCreator.Solution;

public class Address
{
    public string? StreetName { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Region { get; set; }
    public string? Country { get; set; }

    public void AssignAddress(Address address)
    {
        StreetName = address.StreetName;
        City = address.City;
        Country = address.Country;
        PostalCode = address.PostalCode;
        Region = address.Region;
    }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public Address? Address { get; set; }
    
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

public enum EmployeeTypes
{
    HR,
    Standard
}

public abstract class Employee : Person
{
    public abstract int Id { get; }
    public abstract double MonthlySalary { get; set; }
    public abstract EmployeeTypes Type { get; }
    public abstract double GetMonthlyBonus();
    protected Employee(string firstName, string lastName) : base(firstName, lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    public static Employee Create(int id, string firstName, string lastName, double monthlySalary, EmployeeTypes type)
    {
        return (type) switch
        {
            EmployeeTypes.HR => new HR(id, firstName, lastName, monthlySalary),
            EmployeeTypes.Standard => new Standard(id, firstName, lastName, monthlySalary),
            _ => throw new ArgumentOutOfRangeException($"Incorrect value: {type}")
        };
    }
}

public class HR : Employee
{
    public HR(int id, string firstName, string lastName, double monthlySalary) : base(firstName, lastName)
    {
        Id = id;
        MonthlySalary = monthlySalary;
    }

    public override int Id { get; }
    public override double MonthlySalary { get; set; }
    public override EmployeeTypes Type
    {
        get { return EmployeeTypes.HR; }
    }
    
    public override double GetMonthlyBonus()
    {
        return MonthlySalary * 0.1;
    }
}

public class Standard : Employee
{
    public Standard(int id, string firstName, string lastName, double monthlySalary) : base(firstName, lastName)
    {
        Id = id;
        MonthlySalary = monthlySalary;
    }

    public override int Id { get; }
    public override double MonthlySalary { get; set; }
    public override EmployeeTypes Type
    {
        get { return EmployeeTypes.Standard; }
    }
    public override double GetMonthlyBonus()
    {
        return MonthlySalary * 0.05;
    }
}

public class Company
{
    public string Name { get; set; }
    public Address? Address { get; set; }
    
    public List<Employee> Employees { get; private set; }

    public Company(string name)
    {
        Name = name;
        Employees = new List<Employee>();
    }

    public void AddEmployee(int id, string firstName, string lastName, EmployeeTypes type, double monthlySalary, Address? address = null)
    {
        Employee employee = Employee.Create(id, firstName, lastName, monthlySalary, type);
        employee.Address = address;
        Employees.Add(employee);
    }

    public void UpdateEmployeeSalary(int id, double salary)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
            throw new Exception("Employee not found");

        employee.MonthlySalary = salary;
    }
}