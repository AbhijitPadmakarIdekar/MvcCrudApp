using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using WebApp.DataAccess.Context;
using WebApp.Domain.Entities;
using WebApp.Domain.Repository;

namespace WebApp.DataAccess.Implementation
{
    public class SearchParameterRepository : GenericRepository<SearchParameter>, ISearchParameterRepository
    {
        public SearchParameterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            SearchParameter = dbContext.Set<SearchParameter>();
        }

        protected readonly DbSet<SearchParameter> SearchParameter;

        // Method to convert the object to JSON
        public string ToJson(SearchParameter searchParameter)
        {
            // Set the JsonData property
            searchParameter.JsonData = JsonSerializer.Serialize(searchParameter);

            return searchParameter.JsonData;
        }

        // Method to deserialize JSON to object
        public SearchParameter FromJson(string jsonString)
        {
            return JsonSerializer.Deserialize<SearchParameter>(jsonString);
        }
    }
}
