using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA_Repository.Repositories
{
    public class PersonRepository : BaseRepository<Person>
    {
        public PersonRepository(DbContext db) : base(db)
        {
        }

        #region CRUB

        public IQueryable<Person> GetAllPersons()
        {
            return GetAll().Include(p=>p.Addresses);
        }

        public bool InsertPerson(Person Person)
        {
            return Insert(Person);
        }
        public void UpdatePerson(Person Person)
        {
            Update(Person);
        }
        public void DeletePerson(int id)
        {
            Delete(id);
        }

        public bool CheckPersonExists(Person Person)
        {
            return GetAny(b => b.ID == Person.ID||b.EMailAdress== Person.EMailAdress);
        }

        public Person GetPersonById(int id)
        {
            return GetAllPersons().FirstOrDefault(c => c.ID == id);
        }
        public Person GetlastPersonId()
        {
            return GetAllPersons().OrderByDescending(p=>p.ID).FirstOrDefault();
        }

        #endregion
    }
}
