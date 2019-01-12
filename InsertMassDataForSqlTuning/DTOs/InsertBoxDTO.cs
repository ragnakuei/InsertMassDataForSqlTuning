using System.Collections.Generic;

namespace InsertMassDataForSqlTuning.DTOs
{
    public class InsertBoxDTO
    {
        public DeptLevelDTO[] DeptLevels  { get; set; }
        public List<DeptDTO>  Departments { get; set; }
    }
}