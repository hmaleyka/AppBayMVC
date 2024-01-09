using AppBay.Business.Services.Interfaces;
using AppBay.Business.ViewModels.FeatureVM;
using AppBay.Core.Entities;
using AppBay.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Business.Services.Implementations
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _repo;

        public FeatureService(IFeatureRepository repo)
        {
            _repo = repo;
        }

        public async Task<Feature> Create(CreateFeatureVM feature)
        {
            Feature features = new Feature()
            {
                Title= feature.Title,
                Description= feature.Description,
                Icon = feature.Icon,
            };
            await _repo.Create(features);
            await _repo.SaveChanges();
            return features;
        }

        public Task<Feature> Delete(CreateFeatureVM feature)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Feature>> GetAllAsync()
        {

            var features = await _repo.GetAllAsync();
            return await features.ToListAsync();
        }

        public Task<Feature> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Feature> Update(UpdateFeatureVM feature)
        {
            throw new NotImplementedException();
        }
    }
}
