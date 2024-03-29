﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using CrudOperation.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace CrudOperation.Models
{
    public partial interface IEmployeeDBContextProcedures
    {
        Task<List<AllSkillsResult>> AllSkillsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DelectEmployee1Async(int? Id, int? value1, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetAllEmployeesResult>> GetAllEmployeesAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetAllEmployeesWithSkillsResult>> GetAllEmployeesWithSkillsAsync(int? id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> InsertEmployeeAsync(string Name, string Email, string Phone, string Gender, string Address, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> InsertEmployeeSkillsAsync(int? employe_id, int? skill_id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> InsertEmployeeWithSkillsAsync(string Name, string Email, string Phone, string Gender, string Address, string Title, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> InsertSkillAsync(string Tittle, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<SelectById1Result>> SelectById1Async(int? value, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
