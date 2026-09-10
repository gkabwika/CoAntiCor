using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO.Incident
{   
    public class SaveDraftResponse
    {
        public WizardDraftState Draft { get; set; } = default!;
        public bool IsConflict { get; set; }
        public WizardDraftState? ServerVersion { get; set; }
    }

}
