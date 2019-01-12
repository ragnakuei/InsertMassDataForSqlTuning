using System;

namespace InsertMassDataForSqlTuning.DTOs
{
    public class DeptDTO
    {
        public Guid   Id          { get; set; }
        public string Code        { get; set; }
        public Guid   DeptLevelId { get; set; }
        public Guid?  ParentId    { get; set; }
    }
}