namespace WebAppStepG6.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>() { 
                new Student(){Id=1,Name="Ahmed1",Address="alex1",ImageURL="m.png"},
                new Student(){Id=2,Name="Ahmed2",Address="alex2",ImageURL="m.jpg"},
                new Student(){Id=3,Name="Ahmed3",Address="alex3",ImageURL="m.png"},
                new Student(){Id=4,Name="Ahmed4",Address="alex4",ImageURL="m.jpg"},
                new Student(){Id=5,Name="Ahmed5",Address="alex4",ImageURL="m.png"},
            };
        }
        public List<Student> GetAll()
        {
            return students;
        }
        public Student GetById(int id)
        {
            return students.FirstOrDefault(s=>s.Id==id);
        }
    }
}
