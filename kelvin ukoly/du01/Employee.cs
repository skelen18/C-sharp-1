namespace du01;

public class Employee
{
    public string Name;
    public int? Age;
    public PhoneNumber? Phone;
    public int Salary;
    public bool? IsActive;

    public Employee(string name, int? age, PhoneNumber? phone, int salary, bool? isActive)
    {
        Name = name;
        Age = age;
        Phone = phone;
        Salary = salary;
        IsActive = isActive;
    }
}

public struct PhoneNumber
{
    public string CountryCode;
    public long NationalNumber;

    public PhoneNumber(string countryCode, long nationalNumber)
    {
        CountryCode = countryCode;
        NationalNumber = nationalNumber;
    }

    public override string ToString()
    {
        return CountryCode + NationalNumber;
    }
}
