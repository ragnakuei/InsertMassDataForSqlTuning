using System;

namespace InsertMassDataForSqlTuning.DTOs
{
    public class Dept
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public Guid DeptLevelId { get; set; }

        public Guid? ParentId { get; set; }
    }
}