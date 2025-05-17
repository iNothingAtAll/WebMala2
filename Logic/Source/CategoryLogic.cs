using Data;
using System.Data;

namespace Logic.Source
{
    public class CategoryLogic
    {
        CategoryData objCat = new CategoryData();

        public DataSet showCategories()
        {
            return objCat.showCategories();
        }

        public bool saveCategory(string _description)
        {
            return objCat.saveCategory(_description);
        }

        public bool updateCategory(int _id, string _description)
        {
            return objCat.updateCategory(_id, _description);
        }

        public bool deleteCategory(int _id)
        {
            return objCat.deleteCategory(_id);
        }
    }
}