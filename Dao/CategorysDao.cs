using System;
using System.Collections.Generic;
using MySqlConnector;

namespace StableManager.Dao
{
    using Beans;
    /// <summary>
    /// カテゴリーテーブルとの接続用Dao
    /// </summary>
    class CategorysDao
    {
        private ConnectSqlStrings connectSqlStrings = new Beans.ConnectSqlStrings();
        MySqlConnection connection;
        public List<Categorys> getCategorys()
        {
            List<Categorys> categoryList = new List<Categorys>();
            try
            {
                connection = new MySqlConnection(connectSqlStrings.ConnectionString);
                connection.Open();
                var sql = $@"SELECT category_id, category_name 
                            FROM categorys Where 1 = 1 ";

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Categorys categorys = new Categorys();
                    categorys.IsChecked = false;
                    categorys.CategoryId = reader.GetInt32(0);
                    categorys.CategoryName = reader.GetString(1);
                    categoryList.Add(categorys);
                }
                reader.Close();

            }
            catch
            {
                Console.WriteLine("接続失敗");
                connection.Close();
                return null;
            }
            Console.WriteLine("接続成功");
            connection.Close();
            return categoryList;
        }
    }
}
