namespace CoAntiCor.Core.Domain
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!; // Citizen, Inspector, Manager, Prosecutor, Executive

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
