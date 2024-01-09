using AppBay.Core.Entities;
using AppBay.DAL.Context;
using AppBay.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.DAL.Repositories.Implementations
{
    public class FeatureRepository : Repository<Feature>, IFeatureRepository
    {
        public FeatureRepository(AppDbContext dbcontext) : base(dbcontext)
        {

        }
    }
}
