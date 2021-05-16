using AutoMapper;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class ResourceService : GenericService<Resource, ResourceModel>
    {
        public ResourceService(IGenericRepo<Resource> genericRepo, IMapper mapper)
            : base(genericRepo, mapper)
        {
        }
    }
}