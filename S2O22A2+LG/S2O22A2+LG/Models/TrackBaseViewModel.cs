
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace S2O22A2_LG.Models
{
    [Table("TrackBaseViewModel")]
    public partial class TrackBaseViewModel
        //: TrackAddViewModel
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrackBaseViewModel()
        {
            
        }

        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]

        public string Name { get; set; }

        public int? AlbumId { get; set; }

        public int MediaTypeId { get; set; }

        public int? GenreId { get; set; }

        [StringLength(220)]
        public string Composer { get; set; }

        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

        //[Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }
    }
}