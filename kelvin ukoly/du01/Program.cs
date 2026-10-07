using du01;

if (args.Length == 0)
{
	return;
}

string csv = File.ReadAllText(args[0]);
Employee[] employees = ParseEmployees(csv);

double? averageAge = AverageAge(employees, out int unknownAgeCount);

Console.WriteLine($"Průměrný věk: {averageAge}");
Console.WriteLine($"Zaměstnanců s neznámým věkem: {unknownAgeCount}");
Console.WriteLine();

bool foundEmployee = false;

foreach (Employee employee in employees)
{
	if (employee.IsActive == true && employee.Salary > 30000 &&
		(employee.Phone == null || employee.Phone.Value.CountryCode != "+421"))
	{
		string phone = employee.Phone?.ToString() ?? "";
		Console.WriteLine($"{employee.Name} | {phone}");
		foundEmployee = true;
	}
}

if (!foundEmployee)
{
	Console.WriteLine("Žádný zaměstnanec neodpovídá filtru.");
}

static Employee[] ParseEmployees(string csv)
{
	string[] lines = csv.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
	Employee[] employees = new Employee[lines.Length - 1];

	for (int i = 1; i < lines.Length; i++)
	{
		string[] values = lines[i].Split(';');

		int? age = null;
		if (int.TryParse(values[1], out int parsedAge))
		{
			age = parsedAge;
		}

		PhoneNumber? phone = ParsePhoneNumber(values[2]);

		int.TryParse(values[3], out int salary);

		bool? isActive = null;
		if (values[4] == "ano")
		{
			isActive = true;
		}
		else if (values[4] == "ne")
		{
			isActive = false;
		}

		employees[i - 1] = new Employee(values[0], age, phone, salary, isActive);
	}

	return employees;
}

static PhoneNumber? ParsePhoneNumber(string text)
{
	if (string.IsNullOrEmpty(text))
	{
		return null;
	}

	foreach (char character in text)
	{
		if (!char.IsDigit(character) && character != '+')
		{
			return null;
		}
	}

	string countryCode = "+420";
	string nationalNumber = text;

	if (text.StartsWith("+"))
	{
		if (text.Length < 5)
		{
			return null;
		}

		countryCode = text.Substring(0, 4);
		nationalNumber = text.Substring(4);
	}

	if (long.TryParse(nationalNumber, out long parsedNumber))
	{
		return new PhoneNumber(countryCode, parsedNumber);
	}

	return null;
}

static double? AverageAge(Employee[] employees, out int unknownAgeCount)
{
	int ageSum = 0;
	int ageCount = 0;
	unknownAgeCount = 0;

	foreach (Employee employee in employees)
	{
		if (employee.Age.HasValue)
		{
			ageSum += employee.Age.Value;
			ageCount++;
		}
		else
		{
			unknownAgeCount++;
		}
	}

	if (ageCount == 0)
	{
		return null;
	}

	return (double)ageSum / ageCount;
}

    