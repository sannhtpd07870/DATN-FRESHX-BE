using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Freshx_API.Models
{
    public partial class Savefile
    {
        [Key]
        public int id { get; set; }
        public string? urlFile { get; set; }
        public string? fileName { get; set; }
    }
}
