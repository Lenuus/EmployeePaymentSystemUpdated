using EmployeePaymentSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application
{
    public interface IRepository<Table> where Table : BaseEntity 
    {
        IQueryable<Table> GetAll();

        Task<Table> GetById(Guid id);

        Task DeleteById(Guid id);

        Task Delete(Table entity);

        Task Update(Table entity);

        Task Create(Table entity);
    }
}
