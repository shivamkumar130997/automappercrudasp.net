using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2O22A2_LG.Models
{
    public class InvoiceWithDetailViewModel: InvoiceBaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvoiceWithDetailViewModel()
        {
        }

        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerCity { get; set; }
        public string Customerstate { get; set; }
        public string CustomerEmployeeFirstName { get; set; }
        public string CustomerEmployeeLastName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceLineWithDetailViewModel> InvoiceLines { get; set; }

    }
}