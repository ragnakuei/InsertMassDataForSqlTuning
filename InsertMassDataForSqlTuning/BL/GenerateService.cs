using System;
using System.Collections.Generic;
using System.Linq;
using InsertMassDataForSqlTuning.DTOs;

namespace InsertMassDataForSqlTuning.Controllers
{
    public class GenerateService
    {
        private readonly GenerateRepository _repository;
        private readonly DeptGenerator      _deptGenerator;
        private readonly DeptLevelGenerator _deptLevelGenerator;

        private readonly int _firstDeptLevelIndex;

        public GenerateService(GenerateRepository repository, DeptGenerator deptGenerator, DeptLevelGenerator deptLevelGenerator)
        {
            _repository         = repository;
            _deptGenerator      = deptGenerator;
            _deptLevelGenerator = deptLevelGenerator;

            _firstDeptLevelIndex = 0;
        }

        public int FirstDeptLevelIndex
        {
            get { return _firstDeptLevelIndex; }
        }

        public void Generate()
        {
            var deptLevels = _deptLevelGenerator.GetAllDeptLevels(this);

            var insertBoxDTO = new InsertBoxDTO
            {
                DeptLevels  = deptLevels
              , Departments = _deptGenerator.GetAllDepartments(deptLevels)
            };

            _repository.Save(insertBoxDTO);
        }
    }
}