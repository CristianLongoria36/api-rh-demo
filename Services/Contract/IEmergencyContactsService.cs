using Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contract
{
    public interface IEmergencyContactsService
    {
        List<EmergencyContactsDTO> Get(long id);
        void Save(List<EmergencyContactsDTO> data, long id);
        void Update(long id, EmergencyContactsDTO data);
        void Delete(long id);
    }
}
