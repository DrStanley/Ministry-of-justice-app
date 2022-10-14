using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.IdentityEntities;
using ministryofjusticeDomain.Interfaces.Repository;

namespace ministryofjusticeDomain.Repositories
{
    public class DepartmentHeadRepo : GenericRepo<DepartmentHead>, IDepartmentHeadRepo
    {

        private readonly ApplicationDbContext _context;

        public DepartmentHeadRepo(ApplicationDbContext context)
            :base(context)
        {
            _context = context;
        }
        public DepartmentHead GetDepartmentHead(int departmentId)
        {
            var department = _context.Departments.Find(departmentId);
            if (department != null)
            {
                var departmentHead = _context.DepartmentHeads.Find(department.DeptHeadId);
                return departmentHead;
            }

            return null;
        }
    }
}
