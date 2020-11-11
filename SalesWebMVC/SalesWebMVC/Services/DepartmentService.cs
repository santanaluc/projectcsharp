using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCContext _context;

        public DepartmentService(SalesWebMVCContext context)
        {
            _context = context;
        }

        //transformando em async utilizando tasks
        public async Task<List<Department>> FindAllAsync()
        {
            //expressão linq só é executada quando é chamada
            return await _context.Department.OrderBy(x => x.Name).ToListAsync(); //toList que chama; toList é sync
        }
    }
}
