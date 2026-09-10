using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO.Incident
{
    public class SaveDraftRequest
    {       
        public WizardDraftState Draft { get; set; } = default!;
    }
}
