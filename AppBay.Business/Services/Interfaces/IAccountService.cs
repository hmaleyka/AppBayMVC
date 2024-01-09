using AppBay.Business.ViewModels.AccountVM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task Register(RegisterVM register);
        
    }
}
