using System;
using System.Collections.Generic;

namespace Product.API.Models
{

    /// <summary>
    /// 相册表
    /// </summary>
    public partial class PmsAlbum
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CoverPic { get; set; }
        public int? PicCount { get; set; }
        public int? Sort { get; set; }
        public string Description { get; set; }
    }
}
