using Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contract
{
    public interface IBeneficiaryService
    {
        List<BeneficiaryDTO> Get(long id);
        void Save(List<BeneficiaryDTO> data, long id);
        void Update(BeneficiaryDTO data, long id);
        void Delete(long id);
        void QuerySave(BeneficiaryDTO data, long id);
    }
}
