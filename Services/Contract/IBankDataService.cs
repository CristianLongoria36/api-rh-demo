using Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contract
{
    public interface IBankDataService
    {
        BankDataDTO GetByID(long employeeID);
        void Save(BankDataDTO data, long employeeID);
        void Update(BankDataDTO data, long id);
        void QuerySave(BankDataDTO data, long employeeID);
        bool AcountNumberExits(int data);
        bool InterbankClabeExist(int data);
    }
}
