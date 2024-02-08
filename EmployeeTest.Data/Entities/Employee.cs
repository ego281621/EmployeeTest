﻿using System;
using System.Collections.Generic;

namespace EmployeeTest.Data.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }
}
