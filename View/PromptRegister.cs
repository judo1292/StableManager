using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StableManager.View
{
    using Beans;
    using Dao;
    public partial class PromptRegister : Form
    {
        Categorys space = new Categorys { CategoryId = 0, CategoryName = "" };
    public PromptRegister()
        {
            InitializeComponent();


            CategorysDao categorysDao = new CategorysDao();
            var categoryList = categorysDao.getCategorys();
            categoryList.Add(space);
            comboBoxCategory.DataSource = categoryList;
            comboBoxCategory.DisplayMember = "CategoryName";
            comboBoxCategory.ValueMember = "CategoryId";
            comboBoxCategory.SelectedItem = space;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPrompt();
        }
        private void AddPrompt()
        {
            // テキストボックスとかのプロンプトを取り出してクラスにする
            if (textBoxPromptEn.Text == "" 
                || (int)comboBoxCategory.SelectedValue == 0) return;

            Prompt prompt = new Prompt();
            PromptsDao dao = new PromptsDao();

            prompt.Category = (int)comboBoxCategory.SelectedValue;
            prompt.PromptEn = textBoxPromptEn.Text;
            prompt.PromptJp = textBoxPromptJp.Text;
            prompt.Memo = textBoxMemo.Text;
            prompt.IsNegative = checkBoxIsNegative.Checked;
            prompt.IsBookmark = checkBoxIsBookmark.Checked;

            var result = dao.SeartchPrompt(prompt.PromptEn);

            if(result == true)
            {
                MessageBox.Show("すでに登録されている");
            }
            else if(result == false)
            {
                if (dao.AddPrompt(prompt))
                {
                    MessageBox.Show("登録完了");
                    formReset();
                }
                else
                {
                    MessageBox.Show("登録できなかった");
                }
            }
            else
            {
                MessageBox.Show("何らかのエラー");
            }

        }
        private void formReset()
        {
            comboBoxCategory.SelectedItem = space;
            textBoxPromptEn.Text = "";
            textBoxPromptJp.Text = "";
            textBoxMemo.Text = "";
            checkBoxIsNegative.Checked = false;
            checkBoxIsBookmark.Checked = false;
        }
    }
}
