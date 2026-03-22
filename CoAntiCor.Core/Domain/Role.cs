namespace CoAntiCor.Core.Domain
{
    /// <summary>
    /// Used in policies
    /// <- Admin
    /// <- Citizen
    /// <- InternalStaff
    /// <- Manager
    /// <- Executive
    /// <- Inspector
    /// <- Prosecutor
    /// <- SpecialInvestigator
    /// </summary>
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!; // Citizen, Inspector, Manager, Prosecutor, Executive

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
