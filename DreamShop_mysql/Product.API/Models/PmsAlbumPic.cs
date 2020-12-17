using System;
using System.Collections.Generic;

namespace Product.API.Models
{
    public partial class PmsAlbumPic
    {
        public long Id { get; set; }
        public long? AlbumId { get; set; }
        public string Pic { get; set; }
    }
}
