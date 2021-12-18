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
    public class AddressRepository : BaseRepository<Address>
    {
        public AddressRepository(DbContext db) : base(db)
        {
        }

        #region CRUB

        public IQueryable<Address> GetAllAddresses()
        {
            return GetAll().Include(a=>a.Person);
        }

        public bool InsertAddress(Address Address)
        {
            return Insert(Address);
        }
        public void UpdateAddress(Address Address)
        {
            Update(Address);
        }
        public void DeleteAddress(int id)
        {
            Delete(id);
        }

        public bool CheckAddressExists(Address Address)
        {
            return GetAny(b => b.Id == Address.Id);
        }

        public Address GetAddressById(int id)
        {
            return GetAllAddresses().FirstOrDefault(c => c.Id == id);
        }
        public IQueryable<Address> GetAddressByPersonId(int id)
        {
            return GetAllAddresses().Where(c => c.Person_Id == id);
        }

        #endregion
    }
}
