using CoreAPI.Domain.Entities;
using CoreAPI.Domain.Interfaces.Repositories;
using CoreAPI.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CoreAPI.Infra.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly SQLiteDbContext _context;

        public ServiceRepository(SQLiteDbContext context)
        {
            _context = context;
        }

        public void Add(Machine entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Machine entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Machine> Get()
        {
            return _context.Machines
                .Include(x=>x.AntivirusInfo)
                .Include(x=>x.HardDriveInfos)
                .ToList();
        }

        public IEnumerable<Machine> Get(Expression<Func<Machine, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Machine Subscribe(Machine serviceInfo)
        {
            var result = _context.Machines.Add(serviceInfo);
            _context.SaveChanges();
            return result.Entity;
        }

        public Machine Unsubscribe(Machine serviceInfo)
        {
            _context.Machines.Remove(serviceInfo);
            _context.SaveChanges();
            return serviceInfo;
        }

        public void Update(Machine entity)
        {
            throw new NotImplementedException();
        }
    }
}
