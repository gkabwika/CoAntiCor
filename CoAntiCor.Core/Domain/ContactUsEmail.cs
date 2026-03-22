using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoAntiCor.Core.Domain
{
    public class ContactUsEmail : EntityBaseObject
    {
        
         //[Required(ErrorMessage = "EmailFrom Required")]
        [Display(Name = "Email From"), StringLength(256, MinimumLength = 1)]
        public string EmailFrom { get; set; }
        //[Required(ErrorMessage = "EmailTo Required")]
        [Display(Name = "Email To"), StringLength(4096, MinimumLength = 1)]
        public string EmailTo { get; set; }
        [Display(Name = "Email CC"), StringLength(4096)]
        public string EmailCC { get; set; }
        [Display(Name = "Email BCC"), StringLength(4096)]
        public string EmailBCC { get; set; }
        //[Required(ErrorMessage = "Subject Required")]
        [Display(Name = "Subject"), StringLength(512, MinimumLength = 1)]
        public string Subject { get; set; }
       //[Required(ErrorMessage = "Body Required")]
        [Display(Name = "Message")]
        public string Body { get; set; }

        //public string LDAPLoginName { get; set; }

        //public virtual ICollection<EmailTemplate> EmailTemplates { get; }

    }
}