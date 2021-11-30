using grpahQL_initial.Data;
using grpahQL_initial.Models;
using HotChocolate;
using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grpahQL_initial.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemData> GetItem([Service] ApiDbContext context)
        {
            return context.HolidayMasters;
        }
    }
}
