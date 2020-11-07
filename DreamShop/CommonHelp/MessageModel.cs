using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonHelp
{
    public class MessageModel<T>
    {

        /// <summary>
        /// 状态码
        /// </summary>
        public int Status { get; set; } = 200;

        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool Success { get; set; } = false;

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 返回数据集合
        /// ResponseJson =new JsonArray() { new {A=1 },new {B="1" } }
        /// </summary>
        public JsonArray ResponseJson { get; set; }

        public T Response { get; set; }
    }
}
