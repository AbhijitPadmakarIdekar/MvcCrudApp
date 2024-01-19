using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        }

        // Method to convert the object to JSON
        public string ToJson()
        {
            // Exclude JsonData property from serialization
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault
            };

            return JsonSerializer.Serialize(this, options);
        }

        // Method to deserialize JSON to object
        public static SearchParameter FromJson(string jsonString)
        {
            return JsonSerializer.Deserialize<SearchParameter>(jsonString);
        }
    }
}
