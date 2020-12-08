using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travauxp2.Models.repositories
{
   public interface ISchoolRepository
    {
        IList<School> GetAll();
        School GetById(int id);
        void Add(School s);
        void Edit(School s);
        void Delete(School s);
        double StudentAgeAverage(int schoolId);
        int StudentCount(int schoolId);
    }
}
