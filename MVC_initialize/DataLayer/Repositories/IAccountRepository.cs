using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Repositories
{
    public interface IAccountRepository:IRegister,IUser,ILogin
    {
    }

    public interface IRegister
    {
        bool isExistEmail(string email);
        bool isExitUserName(string userName);
        void addUser(Users user);
        
    }

    public interface IUser
    {
        Users getUserByActivationCode(string activationCode);
    }
    public interface ILogin
    {
        Users getUserByEmailAndHashedPassword(string email, string hashedPassword);
    }
    public interface IForgetPassword
    {
       
    }

}
