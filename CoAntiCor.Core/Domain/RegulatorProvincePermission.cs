using CoAntiCor.Core.Domain.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain
{
    public class RegulatorProvincePermission : EntityBaseObject
    {
        public new Guid Id { get; set; } = Guid.NewGuid();

        // The regulator / executive user who has this permission
        public Guid UserId { get; set; }
        public ApplicationUser? User { get; set; }

        // The province this regulator is allowed to impersonate / view
        public string ProvinceCode { get; set; } = default!;

        // Optional: link to a Province entity if you have one
        public Province? Province { get; set; }

        // Optional: audit metadata
        public DateTime GrantedAtUtc { get; set; } = DateTime.UtcNow;
        public Guid? GrantedByUserId { get; set; }
    }
}
