using System;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Functions;
using Newtonsoft.Json.Linq;

namespace StableManager.Model
{
    using Beans;
    /// <summary>
    /// HTTPリクエスト関連、Stable diffusionとの接続などを担う
    /// </summary>
    class webControll
    {
        public enum Mode
        {
            txt2img,
            options,
            img2img,
            tagger,
        }
      
        /// <summary>
        /// ボディをJsonに変換する
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public string BodyMaker(object payload)
        {
            var payloadJson = JsonConvert.SerializeObject(payload);
            return payloadJson;
        }
    
        /// <summary>
        /// StableDiffusionにHTTPリクエストを送りレスポンスをもらう
        /// </summary>
        /// <param name="body"></param>
        /// <param name="mode"></param>
        public string SendRequest(string body = "", int mode = (int)Mode.txt2img)
        {
            string result = "";
            try
            {
                WebRequest request = HeaderMaker((Mode)mode);
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
                    //if (mode != 0) return result; 
                    result = responsefromserver;
                    var jj = Converter.Json.ToJobject(responsefromserver);
                    JArray aaa = (JArray)jj["images"];
                    byte[] imageBytes = Convert.FromBase64String((string)aaa[0]);
                }
                return result;
            }
            catch
            {
                Console.WriteLine("エラー　sdConnect 接続");
                return result;
            }
        }
      
        /// <summary>
        /// Stable Diffusionへのリクエスト種類を指定して作る
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        private WebRequest HeaderMaker(Mode mode)
        {

            string url = "http://127.0.0.1:7860/sdapi/v1/txt2img";
            switch (mode)
            {
                case Mode.txt2img:
                    {
                        url = "http://127.0.0.1:7860/sdapi/v1/txt2img";
                        break;
                    }
                case Mode.options:
                    {
                        url = "http://127.0.0.1:7860/sdapi/v1/options";
                        break;
                    }
                case Mode.img2img:
                    {
                        url = "http://127.0.0.1:7860/sdapi/v1/img2img";
                        break;
                    }
                case Mode.tagger:
                    {
                        url = "http://127.0.0.1:7860/tagger/v1/interrogate";
                        break;
                    }
                default:

                    {
                        break;
                    }
            }

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            return request;
        }

    }
}
