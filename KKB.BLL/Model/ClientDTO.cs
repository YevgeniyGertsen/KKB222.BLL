﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.Model
{
    public class ClientDTO: IClientDTOShort, IClientDTOAutInfo
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SurName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        public string ShortName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(MiddleName))
                {
                    return string.Format("{0} {1}. {2}.",
                        Name, SurName[0], MiddleName[0]);
                }
                else
                {
                    return string.Format("{0} {1}.", Name, SurName[0]);
                }
            }
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Dob { get; set; }
        /// <summary>
        /// Возраст клиента
        /// </summary>
        public int GetAge
        {
            get
            {
                return DateTime.Now.Year - Dob.Year;
            }
        }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }

        public string Password { get; set; }

        public List<AddressDTO> Address { get; set; }
        public List<AccountDTO> Account { get; set; }
    }

    public interface IClientDTOShort
    {
        int Id { get; set; }
        string Name { get; set; }
        string SurName { get; set; }
        string MiddleName { get; set; }
    }

    public interface IClientDTOAutInfo
    {
        string PhoneNumber { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}
