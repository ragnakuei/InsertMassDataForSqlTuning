using System;
using System.Collections.Generic;
using System.Linq;
using InsertMassDataForSqlTuning.DTOs;

namespace InsertMassDataForSqlTuning.Controllers
{
    public class DeptGenerator
    {
        private readonly int _deptsPerLevel;

        private char _deptCodePrefix;

        public DeptGenerator()
        {
            _deptsPerLevel  = 2;
            _deptCodePrefix = 'A';
        }

        public List<DeptDTO> GetAllDepartments(DeptLevelDTO[] deptLevels)
        {
            var result      = new List<DeptDTO>();
            var parentDepts = new List<DeptDTO>();

            foreach ( var deptLevel in deptLevels )
            {
                var depts = GenerateDepts(deptLevel, parentDepts);
                result.AddRange(depts);

                parentDepts = depts;
            }

            return result;
        }

        private List<DeptDTO> GetRootDepts(DeptLevelDTO deptLevel)
        {
            var result = new List<DeptDTO>
            {
                new DeptDTO
                {
                    Id          = new Guid($"D0000000-0000-0000-00{deptLevel.Index:00}-0000000000{1:00}")
                  , Code        = $"{_deptCodePrefix}{1:0000}"
                  , DeptLevelId = deptLevel.Id
                }
            };
            return result;
        }

        private List<DeptDTO> GenerateDepts(DeptLevelDTO deptLevel, List<DeptDTO> parentDepts)
        {
            if ( deptLevel.Index == 0 )
            {
                parentDepts = GetRootDepts(deptLevel);
                return parentDepts;
            }

            var result = parentDepts.SelectMany(pd => Enumerable.Range(1, _deptsPerLevel)
                                                                .Select(i =>
                                                                 {
                                                                     var dept = new DeptDTO
                                                                     {
                                                                         Id          = new Guid($"D0000000-0000-0000-00{deptLevel.Index:00}-0000000000{i:00}")
                                                                       , Code        = $"{_deptCodePrefix}{i:0000}"
                                                                       , DeptLevelId = deptLevel.Id
                                                                       , ParentId    = pd.Id
                                                                     };
                                                                     return dept;
                                                                 })
                                               )
                                    .ToList();
            _deptCodePrefix++;
            return result;
        }
    }
}