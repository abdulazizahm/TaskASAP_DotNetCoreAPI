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
    public class PersonAppService: BaseAppService<Person>
    {
        public PersonAppService(IUnitOfWork _unit) : base(_unit)
        {
        }

        public List<PersonViewModel> GetAllPersons()
        {
            return Mapper.Map<List<PersonViewModel>>(TheUnitOfWork.Person.GetAllPersons());
        }
     

        public PersonViewModel GetById(int id)
        {
            return Mapper.Map<PersonViewModel>(TheUnitOfWork.Person.GetPersonById(id));
        }

        public Person GetByModelId(int id)
        {
            return TheUnitOfWork.Person.GetPersonById(id);
        }


        public bool SaveNewPerson(PersonViewModel PersonViewModel)
        {
            bool result = false;
            var Person = Mapper.Map<Person>(PersonViewModel);
            if (TheUnitOfWork.Person.InsertPerson(Person))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdatePerson(PersonViewModel PersonViewModel)
        {
            var Person = Mapper.Map<Person>(PersonViewModel);
            
            TheUnitOfWork.Person.UpdatePerson(Person);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool UpdatePersonMyModel(Person Person,int id)
        {
            var Personupdate = GetByModelId(id);
            if (Personupdate != null) 
            {
                Personupdate.Age = Person.Age;
                Personupdate.FamilyName = Person.FamilyName;
                Personupdate.Name = Person.Name;
                Personupdate.EMailAdress = Person.EMailAdress;
                Personupdate.Addresses = Person.Addresses;
                TheUnitOfWork.Person.UpdatePerson(Personupdate);
                TheUnitOfWork.Commit();
                return true;
            }
            return false;
        }
        public bool DeletePerson(int id)
        {
            TheUnitOfWork.Person.DeletePerson(id);
            bool result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckPersonExists(PersonViewModel PersonViewModel)
        {
            Person Person = Mapper.Map<Person>(PersonViewModel);
            return TheUnitOfWork.Person.CheckPersonExists(Person);
        }
        public int GetlastInsertedPersonId()
        {
            return TheUnitOfWork.Person.GetlastPersonId().ID;
        }
        public Person GetlastInsertedPerson()
        {
            return TheUnitOfWork.Person.GetlastPersonId();
        }

    }
}
