using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Model
{
    /// <summary>
    /// Background Cleanup for Old or Abandoned Drafts
    /// Drafts should not live forever.
    /// We’ll implement a background hosted service that:
    /// - Runs once per day
    /// - Deletes drafts older than X days(e.g., 30 days)
    /// - Deletes drafts marked as completed
    /// - Optionally deletes temp attachments

    /// </summary>
    public class DraftRetentionSettings
    {
        public int DaysToKeepDrafts { get; set; } = 30;
    }
}
