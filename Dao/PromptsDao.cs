using System;
using System.Collections.Generic;
using MySqlConnector;
using System.ComponentModel;

namespace StableManager.Dao
{
    using Beans;
    /// <summary>
    /// プロンプトテーブルとの接続用DAO
    /// </summary>
    class PromptsDao
    {

        private Beans.ConnectSqlStrings connectSqlStrings = new Beans.ConnectSqlStrings();
        MySqlConnection connection;
        public PromptsDao()
        {
        }
        public List<Beans.Prompt> getPrompts(StableManager.View.SearchPromptPanel promptPanel, BindingList<Categorys> categorylist)
        {
            List<Beans.Prompt> promptsList = new List<Beans.Prompt>();
            try
            {
                connection = new MySqlConnection(connectSqlStrings.ConnectionString);
                connection.Open();
                var sql = $@"SELECT id, category_id, prompt_en, prompt_jp, memo,is_negative, is_bookmark 
                            FROM prompts Where 1 = 1 ";

                if (promptPanel.IsNegative)
                {
                    sql += $" AND is_negative = true ";
                }
                else { sql += $" AND is_negative = false "; }

                if (promptPanel.IsBookmarkOnly)
                {
                    sql += $" AND is_bookmark = true";
                }

                if (promptPanel.Word != "")
                {
                    sql += $" AND (prompt_jp LIKE '%{promptPanel.Word}%' ";
                    sql += $" OR prompt_en LIKE '%{promptPanel.Word}%') ";
                }

                var fgh = "";
                bool isCategoryChoiced = false;
                foreach (var category in categorylist)
                {
                    if (category.IsChecked)
                    {
                        isCategoryChoiced = true;
                        fgh += $"OR category_id = {category.CategoryId} ";
                    }
                }
                if (isCategoryChoiced)
                {
                    sql += "and (category_id = null " + fgh + ")";
                }
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Beans.Prompt prompts = new Beans.Prompt();
                    prompts.Id = reader.GetInt32(0);
                    prompts.Category = reader.GetInt32(1);
                    prompts.PromptEn = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    prompts.PromptJp = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    prompts.Memo = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    prompts.IsNegative = reader.GetBoolean(5);
                    prompts.IsBookmark = reader.GetBoolean(6);
                    promptsList.Add(prompts);
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
            return promptsList;
        }
        public void getPromptNames(BindingList<Beans.Prompt> list)
        {
            try
            {
                connection = new MySqlConnection(connectSqlStrings.ConnectionString);
                connection.Open();

                foreach (var data in list)
                {
                    if (data.PromptJp != "") continue;
                    var pron = data.PromptEn.Replace("_", " ");
                    var sql = "SELECT prompt_jp,category_id  FROM prompts WHERE 1 = 1 ";
                    sql += $" AND prompt_en = '{data.PromptEn}'";
                    Console.WriteLine(sql);
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        data.PromptJp = reader.GetString(0);
                        data.Category = reader.GetInt32(1);
                    }
                    reader.Close();
                }
            }
            catch
            {
                Console.WriteLine("接続失敗");
                connection.Close();
                return;
            }
            Console.WriteLine("接続成功");
            connection.Close();
            return;
        }
        /// <summary>
        /// 登録しようとしているプロンプトがすでにあるかどうか確認
        /// すでにあればtrue、なければfalseを返す
        /// </summary>
        public bool? SeartchPrompt(string prompt)
        {
            try
            {
                connection = new MySqlConnection(connectSqlStrings.ConnectionString);
                connection.Open();

                var sql = "SELECT prompt_en FROM prompts WHERE 1 = 1 ";
                sql += $" AND prompt_en = '{prompt}' LIMIT 1";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("接続成功");
                    connection.Close();
                    reader.Close();
                    return true;
                }
                return false;
            }
            catch
            {
                Console.WriteLine("接続失敗");
                connection.Close();
                return null;
            }
        }
        /// <summary>
        /// プロンプトを１件追加　成功すればtrue
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public bool AddPrompt(Prompt prompt)
        {
            try
            {
                connection = new MySqlConnection(connectSqlStrings.ConnectionString);
                connection.Open();

                var sql = "INSERT INTO prompts(category_id,prompt_en, prompt_jp, memo, is_negative, is_bookmark) " +
                    $"values({prompt.Category},'{prompt.PromptEn}', '{prompt.PromptJp}', '{prompt.Memo}', {prompt.IsNegative} ,{prompt.IsBookmark}) ";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();

                Console.WriteLine("接続成功");
                connection.Close();
                return true;
            }
            catch
            {
                Console.WriteLine("接続失敗");
                connection.Close();
                return false;
            }
        }

    }
}
