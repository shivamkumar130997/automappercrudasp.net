using S2O22A2_LG.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2O22A2_LG.Models
{
    public class InvoiceBaseViewModel
    {

    
         [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvoiceBaseViewModel()
        {
            
        }
        [Key]
        public int InvoiceId { get; set; }
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }
        [Display(Name = "Invoice Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDate { get; set; }

        [StringLength(70)]
        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; }

        [StringLength(40)]
        [Display(Name = "City")]
        public string BillingCity { get; set; }

        [StringLength(40)]
        [Display(Name = "State")]
        public string BillingState { get; set; }

        [StringLength(40)]
        [Display(Name = "Country")]
        public string BillingCountry { get; set; }

        [StringLength(10)]
        [Display(Name = "PostalZip Code")]
        public string BillingPostalCode { get; set; }

        [Display(Name = "Invoice Total")]
        public decimal Total { get; set; }

        public virtual Customer Customer { get; set; }

       
    }
}