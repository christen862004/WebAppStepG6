using WebAppStepG6.Models;

namespace WebAppStepG6.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        StepsContext context;
        public EmployeeRepository(StepsContext _context)
        {
            context =_context ;// new StepsContext();
        }
        //CRDU
        public void Add(Employee entity)
        {
            context.Employees.Add(entity);
        }

        public void Delete(int id)
        {
            Employee emp = GetById(id);
            context.Employees.Remove(emp);
        }

        public List<Employee> GetAll()//paingination
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            //First ,FirstOrDefault , single, SingleORDefault
            return context.Employees.FirstOrDefault(e=>e.Id==id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Employee entity)
        {
            Employee empFromDB = GetById(entity.Id);
            empFromDB.Name= entity.Name;
            empFromDB.Salary= entity.Salary;
            empFromDB.DepartmentId= entity.DepartmentId;
            empFromDB.ImageUrl = entity.ImageUrl;
        }
    }
}
