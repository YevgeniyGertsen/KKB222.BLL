using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace KKB.DAL.Model
{
    public class AccountRepository
    {
        private readonly string connectionString = "";
        public AccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public AccountReturnResult GetAccounts()
        {
            AccountReturnResult result = new AccountReturnResult();
            result.Accounts = null;
            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    result.Accounts = db.GetCollection<Account>("Account").FindAll().ToList();
                }
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Exception = ex;
            }

            return result;
        }

        public AccountReturnResult GetAccounts(int clientId)
        {
            AccountReturnResult result = new AccountReturnResult();
            result.Accounts = null;
            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    result.Accounts = db.GetCollection<Account>("Account")
                        .FindAll()
                        .Where(w=>w.ClientId == clientId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Exception = ex;
            }

            return result;
        }

        public AccountReturnResult CreateAccount(Account account)
        {
            AccountReturnResult result = new AccountReturnResult();

            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    var accounts = db.GetCollection<Account>("Account");
                    accounts.Insert(account);
                }
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Exception = ex;
            }

            return result;
        }

        public AccountReturnResult GetAccountById(int accountId)
        {
            AccountReturnResult result = new AccountReturnResult();

            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    result.Account = db.GetCollection<Account>("Account")
                        .FindById(accountId);
                }
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Exception = ex;
            }

            return result;
        }

        public AccountReturnResult Pay(Account accunt)
        {
            AccountReturnResult result = new AccountReturnResult();

            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    var accounts = db.GetCollection<Account>("Account");
                    accounts.Update(accunt);
                }
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Exception = ex;
            }

            return result;
        }


    }
}
