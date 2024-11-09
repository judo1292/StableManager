using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StableManager.View
{
    using Dao;
    using Beans;
    public partial class SearchPromptPanel : Form
    {
        BindingList<Categorys> categoryTable = new BindingList<Categorys>();
        BindingList<Prompt> promptTable = new BindingList<Prompt>();
        private bool isBookmarkOnly = false;
        private bool isNegative = false;
        private string word = "";

        public bool IsBookmarkOnly { get => isBookmarkOnly; set => isBookmarkOnly = value; }
        public bool IsNegative { get => isNegative; set => isNegative = value; }
        public string Word { get => word; }

        public SearchPromptPanel()
        {
            InitializeComponent();
            CategorysDao categorysDao = new CategorysDao();
            var categoryList = categorysDao.getCategorys();
            if (categoryList != null)
            {
                foreach (Categorys category in categoryList)
                {
                    categoryTable.Add(category);
                }
            }
            dataGridViewCategory.DataSource = categoryTable;
            dataGridViewCategory.Columns["IsChecked"].CellTemplate = new DataGridViewCheckBoxCell();
            dataGridViewCategory.Columns["IsChecked"].Width = 30;
            dataGridViewCategory.Columns["CategoryId"].Width = 30;

            dataGridViewPrompt.DataSource = promptTable;
            // グリッドから除外する項目名のリスト
            string[] notVisibleList = new string[] { "IsActive", "Id", "Category", "IsNegative", "IsBookmark", "IsRandom", "PrimaryLevel" };

            // グリッドの幅を調整するリスト
            List<(string ColumnName, int Width)> columnWidthPairs = new List<(string, int)>
            {
                ("IsActive",30),
                ("IsRandom",30),
                ("PrimaryLevel",30)
            };

            foreach (string notVisivle in notVisibleList)
            {
                dataGridViewPrompt.Columns[$"{notVisivle}"].Visible = false;
            }
            foreach (var col in columnWidthPairs)
            {
                dataGridViewPrompt.Columns[col.ColumnName].Width = col.Width;
            }



        }

        #region control


        private void buttonLoad_Click(object sender, EventArgs e)
        {
            promptTable.Clear();
            PromptsDao dao = new PromptsDao();
            var PromptList = dao.getPrompts(this, categoryTable);


            foreach (Prompt prompt in PromptList)
            {
                promptTable.Add(prompt);
            }
            dataGridViewPrompt.DataSource = promptTable;
            dataGridViewCategory.Refresh();
        }

        public enum CategoryName
        {
            quality,
            taste,
            model,
            camerawork,
            light,
            gender,
            body,
            hairstyle,
            face,
            clothes,
            pause,
            item,
            bodyeffect,
            background,
            backgroundeffects,

        }
        private void dataGridViewPrompt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var prompt = (Prompt)dataGridViewPrompt.Rows[dataGridViewPrompt.CurrentRow.Index].DataBoundItem;
            try
            {
                if (prompt == null) return;

                if (radioButtonAddMain.Checked)
                {
                    if (radioButtonPositive.Checked)
                    {

                        GridPromptList.positiveTableMain.Add(prompt);
                    }
                    else if (radioButtonNegative.Checked)
                    {
                        GridPromptList.negativeTableMain.Add(prompt);
                    }
                }
                else
                {
                    if (radioButtonPositive.Checked)
                    {
                        GridPromptList.positiveTableMain.Add(prompt);
                    }
                    else if (radioButtonNegative.Checked)
                    {
                        GridPromptList.negativeTableMain.Add(prompt);
                    }
                }

            }
            catch
            {
                Console.WriteLine("エラー");
            }
        }


        private void checkBoxIsBookmarkOnly_CheckedChanged(object sender, EventArgs e)
        {
            isBookmarkOnly = checkBoxIsBookmarkOnly.Checked;
        }
        #endregion

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.word = textBoxSearchWords.Text;
        }

        private void checkBoxIsNegative_CheckedChanged(object sender, EventArgs e)
        {
            isNegative = checkBoxIsNegative.Checked;
        }
    }

}
