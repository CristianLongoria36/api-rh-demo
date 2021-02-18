using Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contract
{
    public interface IDivisionService
    {
        PaginationDTO<DivisionDTO> List(int page, int totalByPage, string search);
        void Save(DivisionDTO data);
        void Update(DivisionDTO data, long id);
        bool DivisionNameExist(string name);
        bool DivisionIDExist(long id);
    }
}
