using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace practice_empty_c_mvc_5.Models.Extended
{
    [MetadataType(typeof(ArtistsMetadata))]
    public partial class Artists
    {

    }

    public class ArtistsMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese código del artista")]
        public String art_code { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese nombre del artista")]
        public String art_name { get; set; }
    }
}