using SchoolManagement.SharedKernel;
using SchoolManagement.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
    {
        protected readonly StudentManagementContext _StudentManagementContext;

        public EfRepository(StudentManagementContext studentManagementContext)
        {
            _StudentManagementContext = studentManagementContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _StudentManagementContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _StudentManagementContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _StudentManagementContext.Set<T>().AddAsync(entity);
            await _StudentManagementContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _StudentManagementContext.Entry(entity).State = EntityState.Modified;
            await _StudentManagementContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _StudentManagementContext.Set<T>().Remove(entity);
            await _StudentManagementContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_StudentManagementContext.Set<T>().AsQueryable(), spec);
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }


    }
}
