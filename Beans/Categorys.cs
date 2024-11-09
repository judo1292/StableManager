
namespace StableManager.Beans
{
    /// <summary>
    /// Categoryテーブル用Beans
    /// </summary>
    class Categorys
    {
        public bool IsChecked { get => isChecked; set => isChecked = value; }
        private bool isChecked = false;
        private string categoryName;
        private int categoryId;
        private int categoryMajorId;
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public int CategoryMajorId { get => categoryMajorId; set => categoryMajorId = value; }
    }

}
