using SPG.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataService.Services
{
    public abstract class BaseService
    {
        public readonly DataAccessService DataAccessService;

        public BaseService(DataAccessService dataAccessService)
        {
            DataAccessService = dataAccessService;
        }
    }
}
