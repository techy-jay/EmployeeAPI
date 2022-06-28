using System;
using System.Collections.Generic;

#nullable disable

namespace Employee.Models
{
    public partial class EmsEmployeeMaster
    {
        public int EmId { get; set; }
        public string EmName { get; set; }
        public int? EmCity { get; set; }
        public int? EmDepartment { get; set; }
        public int? EmGender { get; set; }
        public DateTime? EmCreatedAt { get; set; }
        public int? EmCreatedBy { get; set; }
        public DateTime? EmModifyAt { get; set; }
        public int? EmModifyBy { get; set; }
    }
}
