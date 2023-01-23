using SPS.Data.Models;
using SPS.Repository.Interface.Common;
using SPS.Repository.Interface.ProductAdmin;
using SPS.Repository.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Repository.Repository.ProductAdmin
{
    public class CategoryRepository : GenericRepository<CategoryDetail>, ICategoryRepository
    {
        public CategoryRepository(SPSContext context) : base(context)
        {
        }

        public IEnumerable<CategoryDetail> GetCategory()
        {
            return Context.CategoryDetails.ToList();
        }
    }
}
