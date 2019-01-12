using System;
using System.Linq;
using EFCore.BulkExtensions;
using InsertMassDataForSqlTuning.DTOs;
using InsertMassDataForSqlTuning.EF;
using InsertMassDataForSqlTuning.Helpers;

namespace InsertMassDataForSqlTuning.Controllers
{
    public class GenerateRepository
    {
        private readonly DefaultContext _context;

        public GenerateRepository(DefaultContext context) { _context = context; }

        public void Save(InsertBoxDTO insertBoxDTO)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.ChangeTracker.AutoDetectChangesEnabled = false;

                    _context.Depts.AddRange(insertBoxDTO.Departments);
                    _context.DeptLevels.AddRange(insertBoxDTO.DeptLevels);
                    _context.SaveChanges();

                    _context.ChangeTracker.AutoDetectChangesEnabled = true;
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    transaction.Rollback();
                }
            }
        }
    }
}