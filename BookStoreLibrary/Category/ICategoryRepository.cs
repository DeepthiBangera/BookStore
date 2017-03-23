using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary.Category
{
    public interface ICategoryRepository
    {
        void AddCategory(Category b);
        void DeleteCategory(Category b);
        void UpdateCategory(Category b);
        List<Category> GetAllCategory();
        Category GetCategoryByID(int CategoryID);
    }
}
