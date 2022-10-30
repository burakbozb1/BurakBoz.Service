using BurakBoz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Core.Repositories
{
    public interface IMainCategoryRepository:IGenericRepository<MainCategory>
    {
        Task<List<MainCategory>> GetWithSubCategories();
        Task<MainCategory> GetWithSubCategories(int id);

    }
}
