using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travauxp2.Models.repositories
{
    public class StudentRepository : IStudentRepository
    {
        readonly StudentContext context;

        public StudentRepository(StudentContext context)
        {
            this.context = context;
        }
        public void Add(Student s)
        {
            context.Students.Add(s);
            context.SaveChanges();
        }

        public void Delete(Student s)
        {
            Student s1 = context.Students.Find(s.StudentId);
            if (s1 != null)
            {
                context.Students.Remove(s1);
                context.SaveChanges();
            }
        }

        public void Edit(Student newstudent)
        {
            Student oldstudent = context.Students.Find(newstudent.StudentId);
            if (oldstudent != null)
            {
                oldstudent.StudentName = newstudent.StudentName;
                oldstudent.Age = newstudent.Age;
                oldstudent.BirthDate = newstudent.BirthDate;
                oldstudent.SchoolID = newstudent.SchoolID;
                context.SaveChanges();
            }
        }

        public IList<Student> GetAll()
        {
            return context.Students.OrderBy(x => x.StudentName).Include(x => x.School).ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.Where(x => x.StudentId == id).Include(x => x.School).SingleOrDefault();
        }

        public IList<Student> FindByName(string name)
        {
            return context.Students.Where(s => s.StudentName.Contains(name)).Include(std => std.School).ToList();

        }

        public IList<Student> GetStudentsBySchoolID(int? schid)
        {
            return context.Students.Where(s => s.SchoolID.Equals(schid))
               .OrderBy(s => s.StudentName)
               .Include(std => std.School).ToList();

        }
    }
}

