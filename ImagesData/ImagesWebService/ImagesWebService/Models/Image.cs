using System;
using System.Collections.Generic;

namespace ImagesWebService.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsBack { get; set; }
        public byte[] Image1 { get; set; } = null!;
    }
}
