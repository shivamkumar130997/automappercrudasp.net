using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2O22A2_LG.Models
{
    public class InvoiceLineWithDetailViewModel : InvoiceLineBaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvoiceLineWithDetailViewModel()
        {
        }

        public string TrackTrackId { get; set; }
        public string TrackName { get; set; }
        public string TrackAlbumId { get; set; }
        public string TrackComposer { get; set; }
        public decimal TrackUnitPrice { get; set; }

        public string TrackAlbumTitle { get; set; }
        public string TrackAlbumArtistName { get; set; }
        public string TrackMediaTypeName { get; set; }
    }
}