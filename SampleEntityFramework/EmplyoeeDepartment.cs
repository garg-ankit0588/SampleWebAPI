//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmplyoeeDepartment
    {
        public int Id { get; set; }
        public long EmpId { get; set; }
        public int DeptId { get; set; }
    
        public virtual DepartmentMaster DepartmentMaster { get; set; }
        public virtual EmployeeInfo EmployeeInfo { get; set; }
    }
}
