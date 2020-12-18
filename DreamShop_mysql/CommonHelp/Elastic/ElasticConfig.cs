using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonHelp.Help
{
    public class ElasticConfig
    {
        /// <summary>
        /// ES地址
        /// </summary>
        public string ElasticUri { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 日志索引格式
        /// </summary>
        public string IndexFormat { get; set; }
    }
}
