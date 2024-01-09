using AppBay.Business.Exceptions.Feature;
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

        public void  Delete(Feature feature)
        {
            if (feature == null) throw new FeatureNullException();
            _repo.GetById(feature.Id);
             _repo.Delete(feature);

             _repo.SaveChanges();
           
          
        }

        public async Task<ICollection<Feature>> GetAllAsync()
        {

            var features = await _repo.GetAllAsync();
            return await features.ToListAsync();
        }

        public Task<Feature> GetByIdAsync(int id)
        {
            var feature = _repo.GetById(id);
            return feature;
        }

        public async Task<Feature> Update(UpdateFeatureVM feature)
        {
            if (feature == null) throw new FeatureNullException();
            Feature features = await _repo.GetById(feature.Id);
            //features.Id = feature.Id;
            features.Title = feature.Title;
            features.Description = feature.Description;
            features.Icon = feature.Icon;

             _repo.Update(features);
            await _repo.SaveChanges();
            return features;
        }
    }
}
