using Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contract
{
    public interface ISelectService
    {
        List<SelectDTO> SelectRole();
        List<SelectDTO> SelectMarital();
        List<SelectDTO> SelectDivision();
        List<SelectDTO> SelectPosition(long id);
        List<SelectDTO> SelectGender();
        List<SelectDTO> SelectCurrency();
    }
}
