namespace ConsoleApp1.C__Practise.PYnative.Linq;

public sealed class LinqUser
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public string Email { get; init; } = "";
}

public sealed class LinqProduct
{
    public string Name { get; init; } = "";
    public decimal Price { get; init; }
}

public sealed class LinqProductTax
{
    public string ProductName { get; init; } = "";
    public decimal CalculatedTax { get; init; }
}

public sealed class LinqDepartmentWithEmployees
{
    public string Name { get; init; } = "";
    public IReadOnlyList<string> EmployeeNames { get; init; } = Array.Empty<string>();
}

public sealed class LinqBook
{
    public string Title { get; init; } = "";
    public int Year { get; init; }
    public decimal Price { get; init; }
}

public sealed class LinqSalaryEmployee
{
    public string Name { get; init; } = "";
    public string Department { get; init; } = "";
    public decimal Salary { get; init; }
}

public sealed class LinqPerson
{
    public string Name { get; init; } = "";
    public int Age { get; init; }
}

public sealed class LinqStudent
{
    public int StudentId { get; init; }
    public string Name { get; init; } = "";
}

public sealed class LinqCourse
{
    public int StudentId { get; init; }
    public string CourseName { get; init; } = "";
}

public sealed class LinqEmployeeWithDept
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public int DepartmentId { get; init; }
}

public sealed class LinqDepartment
{
    public int Id { get; init; }
    public string DepartmentName { get; init; } = "";
}

public sealed class LinqEmployeeRecord
{
    public string Name { get; init; } = "";
    public string Department { get; init; } = "";
    public decimal Salary { get; init; }
}

public sealed class LinqEmployeeDepartmentRow
{
    public string EmployeeName { get; init; } = "";
    public string DepartmentName { get; init; } = "";
}

public sealed class LinqStudentCourseRow
{
    public string StudentName { get; init; } = "";
    public string CourseName { get; init; } = "";
}
