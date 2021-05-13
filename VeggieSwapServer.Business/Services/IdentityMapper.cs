using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeggieSwapServer.Business.Services
{
    class IdentityMapper<E, O>
    {
        private IMapper _mapper;

        public IdentityMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public O Map(E entity)
        {            
            return _mapper.Map<O>(entity);
        }
    }
}
