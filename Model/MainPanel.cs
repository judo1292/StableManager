using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Collections.Generic;

using System.Windows.Forms;
namespace StableManager.Model
{
    using Beans;
    class MainPanel
    {
        PrePayload settings = PrePayload.Instance;
        private bool isAllCheckPositive = true;
        private bool isAllCheckPositive_Random = false;
        private bool isAllChecknegative_Random = false;
        private bool isAllCheckNegative = true;
        private bool isAllCheckModel = true;

        createPicture a;
        Task task1;

        public bool IsAllCheckPositive { get => isAllCheckPositive; set => isAllCheckPositive = value; }
        public bool IsAllCheckPositive_Random { get => isAllCheckPositive_Random; set => isAllCheckPositive_Random = value; }
        public bool IsAllChecknegative_Random { get => isAllChecknegative_Random; set => isAllChecknegative_Random = value; }
        public bool IsAllCheckNegative { get => isAllCheckNegative; set => isAllCheckNegative = value; }
        public bool IsAllCheckModel { get => isAllCheckModel; set => isAllCheckModel = value; }

        public void RoopStart()
        {
            a = new createPicture();
            task1 = Task.Run(() =>
            {
                a.Roop();
            });
        }
       
        /// <summary>
        /// モデルのリクエストを取得する
        /// </summary>
        public BindingList<Beans.Model> GetModelList()
        {
            GridPromptList.modelTable.Clear();
            string result;
            var model = "arterosBasil_10.safetensors [e4694b936e]";
            BindingList<Beans.Model> models = new BindingList<Beans.Model>();
            try
            {
                var payload = new
                {
                    sd_model_checkpoint = model,

                };
                var payloadJson = JsonConvert.SerializeObject(payload);
                WebRequest request = WebRequest.Create("http://127.0.0.1:7860/sdapi/v1/sd-models");
                request.Method = "GET";
                request.ContentType = "application/json;charset=UTF-8";

                WebResponse response;

                response = request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responsefromserver = reader.ReadToEnd();
                    response.Close();
                    dataStream.Close();
                    result = responsefromserver;
                }
                result = result.Replace('"', '\'');
                JArray jsonArray = JArray.Parse(result);
                string listTmp = "";
                foreach (var i in jsonArray)
                {
                    listTmp += i["title"].ToString();
                    GridPromptList.modelTable.Add(new Beans.Model { Name = i["title"].ToString(), IsChecked = true });

                    if (i != jsonArray.Last)
                    {
                        listTmp += ",";
                    }
                }
                //Mode.modellist = listTmp.Split(',');



            }
            catch
            {
                Console.WriteLine("接続に失敗しました。");
                return null;
            }
            return GridPromptList.modelTable;
        }

        /// <summary>
        /// プロンプト検索画面を表示する
        /// </summary>
        public void ShowSearchPromptPanel()
        {
            View.SearchPromptPanel searchPromptPanel = new View.SearchPromptPanel();
            searchPromptPanel.Show();
        }
        
        public void AllCheckActive(bool isPositive)
        {
            if (isPositive)
            {
                if (IsAllCheckPositive)
                {
                    foreach (var cat in GridPromptList.positiveTableMain)
                    {
                        cat.IsActive = false;
                    }
                    IsAllCheckPositive = false;
                }
                else
                {
                    foreach (var cat in GridPromptList.positiveTableMain)
                    {
                        cat.IsActive = true;
                    }
                    IsAllCheckPositive = true;
                }
            }
            else
            {
                if (IsAllCheckNegative)
                {
                    foreach (var cat in GridPromptList.negativeTableMain)
                    {
                        cat.IsActive = false;
                    }
                    IsAllCheckNegative = false;
                }
                else
                {
                    foreach (var cat in GridPromptList.negativeTableMain)
                    {
                        cat.IsActive = true;
                    }
                    IsAllCheckNegative = true;
                }
            }

        }

        public void AllCheckRandomActive(bool isPositive)
        {
            bool isActive;
            BindingList<Prompt> list;
            if (isPositive) {
                list = GridPromptList.positiveTableMain;
                isActive = IsAllCheckPositive_Random;
    }
            else
            {
                list = GridPromptList.negativeTableMain;
                isActive = IsAllChecknegative_Random;
            }
                
            if (list.Count <= 0) return;
            if (isActive)
            {
                foreach (var cat in list)
                {
                    cat.IsRandom = false;
                }
                isActive = false;
            }
            else
            {
                foreach (var cat in list)
                {
                    cat.IsRandom = true;
                }
                isActive = true;
            }
            //　もっかいやるのダサいからクラスつくるなりして短くするべき
            if (isPositive)
            {
                IsAllCheckPositive_Random = isActive;
            }
            else
            {
                IsAllChecknegative_Random = isActive;
            }
        }

        public void AllCheckEnable(bool isPositive)
        {
            bool isActive;
            BindingList<Prompt> list;
            if (isPositive)
            {
                list = GridPromptList.positiveTableMain;
                isActive = IsAllCheckPositive;
            }
            else
            {
                list = GridPromptList.negativeTableMain;
                isActive = IsAllCheckNegative;
            }

            if (list.Count <= 0) return;
            if (isActive)
            {
                foreach (var cat in list)
                {
                    cat.IsActive = false;
                }
                isActive = false;
            }
            else
            {
                foreach (var cat in list)
                {
                    cat.IsActive = true;
                }
                isActive = true;
            }
            //　もっかいやるのダサいからクラスつくるなりして短くするべき
            if (isPositive)
            {
                IsAllCheckPositive = isActive;
            }
            else
            {
                IsAllCheckNegative = isActive;
            }
        }

        public void AllCheckModel()
        {
            BindingList<Model> list = GridPromptList.modelTable;

            if (list.Count <= 0) return;
            if (IsAllCheckModel)
            {
                foreach (var cat in list)
                {
                    cat.IsChecked = false;
                }
                isAllCheckModel = false;
            }
            else
            {
                foreach (var cat in list)
                {
                    cat.IsChecked = true;
                }
                IsAllCheckModel = true;
            }
            //　もっかいやるのダサいからクラスつくるなりして短くするべき
        }


        public void Translation(bool isPositive)
        {
            BindingList<Prompt> list;
            if (isPositive)
            {
                list = GridPromptList.positiveTableMain;
            }
            else
            {
                list = GridPromptList.negativeTableMain;
            }
            Dao.PromptsDao dao = new Dao.PromptsDao();
            dao.getPromptNames(list);
        }
        public void LoadTextBox(bool isPositive,string text, bool isOverwrite)
        {
            BindingList<Beans.Prompt> list;
            if (text == "") return;
            if (isPositive)
            {
                list = GridPromptList.positiveTableMain;
            }
            else
            {
                list = GridPromptList.negativeTableMain;
            }
            if (isOverwrite)
            {
                list.Clear();
            }

            var pList = text.Split(',');
            for (int i = 0; i < pList.Length; i++)
            {
                int kakko = pList[i].Count(c => c == '{');
                pList[i] = pList[i].Replace("{", "");
                pList[i] = pList[i].Replace("}", "");
                list.Add(new Prompt() {PromptEn = pList[i], PrimaryLevel = kakko });
            }
            Translation(isPositive);

        }

        public void SoatPrompt(bool isPositive)
        {
            BindingList<Prompt> list = GridPromptList.positiveTableMain;
            if (isPositive)
            {
                list = GridPromptList.positiveTableMain;
            }
            else
            {
                list = GridPromptList.negativeTableMain;
            }
            List<Prompt> sortedList =list.OrderBy(item => item.Category).ToList();
            list.Clear();
            foreach (var item in sortedList)
            {
                list.Add(item);
            }
        }
        public void SaveConfig()
        {
            var configFile = JsonConvert.SerializeObject(settings);
            File.WriteAllText(@"config.txt", configFile);
        }
        public void LoadConfig()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            PrePayload configFile = JsonConvert.DeserializeObject<PrePayload>(fileContent);
            PrePayload.Instance = configFile;
        }

    }
}
