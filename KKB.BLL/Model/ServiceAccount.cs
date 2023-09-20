using AutoMapper;
using KKB.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.Model
{
    public class ServiceAccount
    {
        private readonly AccountRepository repo = null;
        private readonly IMapper iMapper;

        public ServiceAccount(string connectionString)
        {
            repo = new AccountRepository(connectionString);
            iMapper = BLLSettings.Init().CreateMapper();
        }


        /// <summary>
        /// Метод возвращает список счетов пользователя
        /// </summary>
        /// <returns></returns>
        public (string message, List<AccountDTO> accounts) GetAllAccounts(int clientId)
        {
            var result = repo.GetAccounts(clientId);
            return (result.Exception.Message, iMapper.Map<List<AccountDTO>>(result.Accounts));
        }

        public (bool result, string message) CreateAccountClient(AccountDTO account)
        {
            var result = repo.CreateAccount(iMapper.Map<Account>(account));

            //return (result.IsError, result?.Exception.Message);
            return (result.IsError, result.Exception!=null ? result.Exception.Message : "");
        }
    }
}
