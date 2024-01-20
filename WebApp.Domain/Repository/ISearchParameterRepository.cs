using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Repository
{
    public interface ISearchParameterRepository : IGenericRepository<SearchParameter>
    {
        string ToJson();
        SearchParameter FromJson(string jsonString);
        SearchParameter GetOrCreate(string username);
    }
}
