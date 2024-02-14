using EmployeePaymentSystem.Domain;
using EmployeePaymentSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application
{
    public class Repository<Table> : IRepository<Table> where Table : BaseEntity
    {
        private readonly MainDbContext _context;
        private DbSet<Table> _table;

        public Repository(MainDbContext context)
        {
            _context = context;
            _table = _context.Set<Table>();
        }

        public async Task Create(Table entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public async Task Delete(Table entity)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var entity = _table.Find(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }

            _table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Table> GetAll()
        {
            return _table;
        }

        public async Task<Table> GetById(Guid id)
        {
            return await _table.FindAsync(id);
        }

        public async Task Update(Table entity)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
