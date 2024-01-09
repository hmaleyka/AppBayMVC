using AppBay.Business.ViewModels.FeatureVM;
using AppBay.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Business.Services.Interfaces
{
    public interface IFeatureService
    {
        Task<ICollection<Feature>> GetAllAsync();
        Task<Feature> GetByIdAsync(int id);
        Task<Feature> Create(CreateFeatureVM feature);
        Task<Feature> Update(UpdateFeatureVM feature);

        void Delete(Feature feature);
    }
}
