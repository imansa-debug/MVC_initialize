using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using DataLayer.Repositories;
using DataLayer.Services;

namespace DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        DbProvider db = new DbProvider();
        private IAccountRepository _accountRepository;
        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(db);
                }

                return _accountRepository;
            }
        }

       
       

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
