using System;
using System.Collections.Generic;
using System.Text;
using Lib;

namespace Services.Contract
{
    public interface IPositionService
    {
        void Save(PositionDTO data, long divisionID);
        void Update(PositionDTO data, long divisionID, long id);
        bool PositionExist(string name, long id);
    }
}
