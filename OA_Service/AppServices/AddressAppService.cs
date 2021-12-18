using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Repository.Identity;
using OA_Service.Bases;
using OA_Service.Interfaces;
using OA_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.AppServices
{
    public class AddressAppService: BaseAppService<Address>
    {
        public AddressAppService(IUnitOfWork _unit) : base(_unit)
        {
        }

        public List<AddressViewModel> GetAllAddresses()
        {
            return Mapper.Map<List<AddressViewModel>>(TheUnitOfWork.Address.GetAllAddresses());
        }
     

        public AddressViewModel GetById(int id)
        {
            return Mapper.Map<AddressViewModel>(TheUnitOfWork.Address.GetAddressById(id));
        }
        public List<AddressViewModel> GetAddressesByPersonId(int id)
        {
            return Mapper.Map<List<AddressViewModel>>(TheUnitOfWork.Address.GetAddressByPersonId(id));
        }

        public Address GetAddressById(int id)
        {
            return TheUnitOfWork.Address.GetAddressById(id);
        }


        public bool SaveNewAddress(AddressViewModel AddressViewModel)
        {
            bool result = false;
            var Address = Mapper.Map<Address>(AddressViewModel);
            if (TheUnitOfWork.Address.InsertAddress(Address))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdateAddress(AddressViewModel AddressViewModel)
        {
            var Address = Mapper.Map<Address>(AddressViewModel);

            TheUnitOfWork.Address.UpdateAddress(Address);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool UpdateAddressMyModel(Address Address)
        { 
            TheUnitOfWork.Address.UpdateAddress(Address);
            TheUnitOfWork.Commit();
            return true;
        }
        public bool DeleteAddress(int id)
        {
            TheUnitOfWork.Address.DeleteAddress(id);
            bool result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckAddressExists(AddressViewModel AddressViewModel)
        {
            Address Address = Mapper.Map<Address>(AddressViewModel);
            return TheUnitOfWork.Address.CheckAddressExists(Address);
        }
    }
}
