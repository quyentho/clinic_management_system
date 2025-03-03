﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace clinic.Models.Repositories
{
    public class AccountRepository: IAccountRepository
    {
        private clinicEntities _clinicEntities;
        public AccountRepository(clinicEntities clinicEntities)
        {
            _clinicEntities = clinicEntities;
        }
        public account GetAccount(string username, string password)
        {
            return _clinicEntities.accounts.Where(a => a.username == username
                                                 && a.pass == password
                                                 && a.is_active == true).FirstOrDefault();
        }
        public void Delete(int staffId)
        {
            var accountFromDb = _clinicEntities.accounts.FirstOrDefault(a => a.staff_id == staffId);
            if (accountFromDb == null)
                throw new ArgumentOutOfRangeException();
            _clinicEntities.accounts.Remove(accountFromDb);
            Save();
        }
        public void Insert(account newAccount)
        {
            _clinicEntities.accounts.Add(newAccount);            
            Save();
        }
        private void Save()
        {
            _clinicEntities.SaveChanges();
        }
        public void Update(account account)
        {
            var accountFromDb = _clinicEntities.accounts.Find(account.id);
            if (accountFromDb != null)
            {
                _clinicEntities.Entry(accountFromDb).CurrentValues.SetValues(account);
                Save();
            }
        }
        public bool CheckExistsAcount(string phoneNumber)
        {
            return _clinicEntities.accounts.Any(a => a.username == phoneNumber);
        }

        public account GetAccountByStaffId(int staffId)
        {
            return _clinicEntities.accounts.Where(a => a.staff_id == staffId)
                     .Where(a => a.is_active == true).FirstOrDefault();
        }
    }
}