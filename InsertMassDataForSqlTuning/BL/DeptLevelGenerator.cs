using System;
using System.Linq;
using InsertMassDataForSqlTuning.DTOs;

namespace InsertMassDataForSqlTuning.Controllers
{
    public class DeptLevelGenerator
    {
        private readonly int _deptLevelCount;

        public DeptLevelGenerator()
        {
            _deptLevelCount = 14;
        }
        
        public DeptLevel[] GetAllDeptLevels(GenerateService generateService)
        {
            return Enumerable.Range(generateService.FirstDeptLevelIndex, _deptLevelCount)
                             .Select(i => new DeptLevel
                              {
                                  Id    = new Guid($"00000000-0000-0000-0000-0000000000{i:00}")
                                , Code  = $"A{i:00}"
                                , Index = i
                              })
                             .ToArray();
        }
    }
}