using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Functions;
using Newtonsoft.Json.Linq;
using MySqlConnector;





namespace StableManager
{
    static class Program
    {
        static private Beans.ConnectSqlStrings connectSqlStrings = new Beans.ConnectSqlStrings();//テスト用あとで消す
        static MySqlConnection connection;//これも

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            const String server = "Server=192.168.10.10;Port=3306;";
            const String userId = "Uid=sa;";
            const String password = "Pwd=judo11822564;";
            const String database = "Database=picturefuriwake";
            string ConnectionString = server + userId + password + database;
        string directoryPath = @"C:\huriwake\jpg"; // ここに目的のディレクトリパスを指定します
            string[] filePaths = Directory.GetFiles(directoryPath);
            foreach (string filePath in filePaths)
            {
                //var tags = Test(filePath);
                try
                {

                    connection = new MySqlConnection(ConnectionString);
                    connection.Open();
                    var sql = $@"SELECT id 
                            FROM image_path Where 1 = 1 ";
                    sql += $"and path ='{filePath}'";
                    Console.WriteLine(sql);
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if(!reader.Read())
                    {
                        reader.Close();
                        sql = "INSERT INTO image_path(path) " +
                    $"values('{filePath}') ";
                        Console.WriteLine(sql);
                        cmd = new MySqlCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                    }
                    reader.Close();

                    sql = $@"SELECT tag FROM `image_tags`
join image_path on image_tags.id = image_path.id
where path = '{filePath}'
LIMIT 1";
                    if (!reader.Read())
                    {
//ここに処理書いてね
                    }

                }
                catch
                {
                    Console.WriteLine("接続失敗");
                    connection.Close();
                }
                Console.WriteLine("接続成功");
                connection.Close();
            }



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new View.MainPanel());
        }
        static List<string> Test(string path)
        {
            List<string> keys;
            try
            {
                string imagePath = path;
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                string base64String = Convert.ToBase64String(imageBytes);

                Beans.interrogator interrogator = new Beans.interrogator();
                interrogator.image = base64String ;
                interrogator.model = "wd14-vit-v2-git";
                interrogator.threshold = 0.35;

                Model.webControll webC = new Model.webControll();
                string body = webC.BodyMaker(interrogator);
                string result = "";
                Console.WriteLine(body);
                WebRequest request = WebRequest.Create("http://127.0.0.1:7860/tagger/v1/interrogate");
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";
                WebResponse response;
                byte[] byteArray = Encoding.UTF8.GetBytes(body);
                request.ContentLength = byteArray.Length;
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                }

                response = request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responsefromserver = reader.ReadToEnd();
                    response.Close();
                    dataStream.Close();
                    result = responsefromserver;
                    //var jj = Converter.Json.ToJobject(responsefromserver);
                    //JArray aaa = (JArray)jj["images"];
                    //byte[] imageBytes = Convert.FromBase64String((string)aaa[0]);
                }
                Console.WriteLine(result);
                var rootObject = JsonConvert.DeserializeObject<RootObject>(result);

                // captionのキーをリストに抽出
               keys = new List<string>(rootObject.Caption.Keys);

                // 結果を表示
                foreach (var key in keys)
                {
                    Console.WriteLine(key);
                }
                //Console.WriteLine(a);
                //Console.WriteLine("waowaowaowaowaowao");
                return keys;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return null;

        }

    }
    public class RootObject
    {
        public Dictionary<string, double> Caption { get; set; }
    }
}
