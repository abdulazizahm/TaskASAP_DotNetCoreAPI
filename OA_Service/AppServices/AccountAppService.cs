using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
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
    public class AccountAppService : BaseAppService<ApplicationUser>
    {
        public AccountAppService(IUnitOfWork _unit) : base(_unit)
        { 
        }

        public ApplicationUser Find(string emial, string password)
        {
            return TheUnitOfWork.Account.Find(emial, password);
        }

        public ApplicationUser FindById(string id) 
        {
            return TheUnitOfWork.Account.Find(id);
        }

        public ApplicationUser FindUserById(string id)
        {
            return TheUnitOfWork.Account.Where(u => u.Id == id).FirstOrDefault();
        }

  

        public IdentityResult AssignToRole(string userId, Role_Name role)
        {
            var user = FindUserById(userId);
            return TheUnitOfWork.Account.AssignToRole(user, role.ToString());
        }


    
        public IdentityResult Update(ApplicationUser user)
        {
            return TheUnitOfWork.Account.Edit(user);
        }

      

        public bool IsInRole(string user_id, Role_Name role)
        {
            var user = FindById(user_id);
            return TheUnitOfWork.Account.IsInRole(user, role);
        }

      
    }
}
