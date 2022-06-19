using System;
using System.ComponentModel.DataAnnotations;
// This is the model for one row in the database table. You may need to make some adjustments.
namespace TelerikBlazorApp1.Data
{
    public class Department
    {
        [Required]
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        public string DeptLocation { get; set; }

    }
}
