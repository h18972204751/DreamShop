using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelp.Help
{
    public class ApiHelper
    {
        /// <summary>
        /// HttpClient实现Post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="message"></param>
        /// <param name="type">0为application/json   1为application/x-www-form-urlencoded</param>
        /// <param name="token">可不传</param>
        /// <returns></returns>
        public static  async Task<T> PostAsync<T>(string url, Dictionary<string, string> message,int type, string token = "") where T : new()
        {
            var res = new T();
            
            string jsonContent = null;
            string responseBody = string.Empty;
            string contenttype = "";
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Method", "Post");
                if(!string.IsNullOrWhiteSpace(token))
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                HttpResponseMessage response = new HttpResponseMessage();
                if (type == 0)
                {
                    contenttype = "application/json";
                    jsonContent = JsonConvert.SerializeObject(message);
                    var content = new StringContent(jsonContent, Encoding.UTF8, contenttype);
                    response = await httpClient.PostAsync(url, content);
                }
                else
                {
                    contenttype = "application/x-www-form-urlencoded";
                    var contentForm = new FormUrlEncodedContent(message);
                    response = await httpClient.PostAsync(url, contentForm);
                }
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                res = (T)JsonConvert.DeserializeObject<T>(responseBody);
            }
            return res;


















            //using (var httpClient = new HttpClient())
            //{
            //    //表头参数
            //    httpClient.DefaultRequestHeaders.Accept.Clear();
            //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    //转为链接需要的格式
            //    HttpContent httpContent = new JsonContent(datajson);
            //    //请求
            //    HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        Task<string> t = response.Content.ReadAsStringAsync();
            //        if (t != null)
            //        {
            //            return t.Result;
            //        }
            //    }
            //    return "";
            //}

            //var res = new T();
            //string jsonContent = JsonConvert.SerializeObject(dic);
            //string responseBody = string.Empty;
            //using (HttpClient httpClient = new HttpClient())
            //{
            //    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            //    httpClient.DefaultRequestHeaders.Add("Method", "Post");
            //    HttpResponseMessage response = await httpClient.PostAsync(url, content);
            //    response.EnsureSuccessStatusCode();
            //    responseBody = await response.Content.ReadAsStringAsync();
            //    res = (T)JsonConvert.DeserializeObject<T>(responseBody);
            //}
            //return res;


            ////设置HttpClientHandler的AutomaticDecompression
            ////var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            ////创建HttpClient（注意传入HttpClientHandler）
            //using (var http = new HttpClient())
            //{
            //    //添加Token
            //    if (!string.IsNullOrWhiteSpace(token))
            //    {
            //        http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            //    }
            //    //使用FormUrlEncodedContent做HttpContent
            //    var content = new FormUrlEncodedContent(dic);
            //    //await异步等待回应
            //    var response = await http.PostAsync(url, content);

            //    //确保HTTP成功状态值
            //    response.EnsureSuccessStatusCode();

            //    //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
            //    string Result = await response.Content.ReadAsStringAsync();

            //    var Item = JsonConvert.DeserializeObject<T>(Result);

            //    return Item;
            //}

        }




    }
}
