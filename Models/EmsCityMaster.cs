using System;
using System.Collections.Generic;

#nullable disable

namespace Employee.Models
{
    public partial class EmsCityMaster
    {
        public int CmId { get; set; }
        public string CmName { get; set; }
        public DateTime? CmCreatedAt { get; set; }
        public int? CmCreatedBy { get; set; }
        public DateTime? CmModifyAt { get; set; }
        public int? CmModifyBy { get; set; }
    }
}
