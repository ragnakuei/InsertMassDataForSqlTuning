using System.Collections.Generic;

namespace InsertMassDataForSqlTuning.DTOs
{
    public class InsertBoxDTO
    {
        public DeptLevel[] DeptLevels  { get; set; }
        public List<Dept>  Departments { get; set; }
    }
}