using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoAntiCor.Core.Domain.CodeTables
{

    public partial class CodeTableExtended : CodeTableBaseObject
    {
       
        public bool IsViewable { get; set; }

        public bool IsErrorVisible { get; set; }
        public string? CodeTableType { get; set; }

    }
}
