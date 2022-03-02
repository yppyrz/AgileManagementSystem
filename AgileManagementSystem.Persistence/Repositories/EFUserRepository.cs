using AgileManagementSystem.Core.Data;
using AgileManagementSystem.Domain.Models;
using AgileManagementSystem.Domain.Repositories;
using AgileManagementSystem.Persistence.EFCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Persistence.EFCore.Repositories
{
    public class EFUserRepository : EFBaseRepository<ApplicationUser, UserDbContext>, IApplicationUserRepository
    {
        public EFUserRepository(UserDbContext dbContext) : base(dbContext)
        {
        }

        public override void Add(ApplicationUser entity)
        {
            base.Add(entity);
        }

        public ApplicationUser FindUserByEmail(string email)
        {
            return _dbSet.FirstOrDefault(x => x.Email == email);
        }
    }
}
