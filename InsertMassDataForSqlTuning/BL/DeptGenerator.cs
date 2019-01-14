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
        private int _deptSerialNo;
        private int _deptLevelSerialNo;

        public DeptGenerator()
        {
            _deptsPerLevel  = 2;
            _deptCodePrefix = 'A';
            _deptSerialNo = 0;
            _deptLevelSerialNo = 0;
        }

        public List<Dept> GetAllDepartments(DeptLevel[] deptLevels)
        {
            var result      = new List<Dept>();
            var parentDepts = new List<Dept>();

            foreach ( var deptLevel in deptLevels )
            {
                var depts = GenerateDepts(deptLevel, parentDepts);
                result.AddRange(depts);

                parentDepts = depts;
            }

            return result;
        }

        private List<Dept> GetRootDepts(DeptLevel deptLevel)
        {
            var result = new List<Dept>
            {
                new Dept
                {
                    Id          = new Guid($"A0000000-00{deptLevel.Index:00}-0000-0000-{_deptSerialNo:000000000000}")
                  , Code        = $"{_deptCodePrefix}{_deptSerialNo++:000000}"
                  , DeptLevelId = deptLevel.Id
                }
            };
            return result;
        }

        private List<Dept> GenerateDepts(DeptLevel deptLevel, List<Dept> parentDepts)
        {
            if ( deptLevel.Index == 0 )
            {
                parentDepts = GetRootDepts(deptLevel);
                return parentDepts;
            }

            var result = parentDepts.SelectMany(pd => 
                                                    Enumerable.Range(1, _deptsPerLevel)
                                                                .Select(i =>
                                                                 {
                                                                     var dept = new Dept
                                                                     {
                                                                         Id          = new Guid($"A0000000-00{deptLevel.Index:00}-0000-0000-{_deptSerialNo:000000000000}")
                                                                       , Code        = $"{_deptCodePrefix}{_deptSerialNo++:000000}"
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