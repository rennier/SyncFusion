using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TelerikBlazorApp1.Data
{
    // Each item below provides an interface to a method in DepartmentServices.cs
    public interface IDepartmentService
    {
        Task<bool> DepartmentInsert(Department department);
        Task<IEnumerable<Department>> DepartmentList();
        Task<IEnumerable<Department>> DepartmentSearch(string Param);
        Task<IEnumerable<Department>> DepartmentDateRange(DateTime @StartDate, DateTime @EndDate);
        Task<Department> Department_GetOne(int DeptID);
        Task<bool> DepartmentUpdate(Department department);
        Task<bool> DepartmentDelete(int DeptID);
    }
}