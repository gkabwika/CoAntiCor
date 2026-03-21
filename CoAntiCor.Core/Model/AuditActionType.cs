namespace CoAntiCor.Core.Model
{
    public enum AuditActionType
    {
        UserLogin,
        UserLoginFailed,
        UserLogout,
        ComplaintCreated,
        ComplaintStatusChanged,
        ComplaintAssigned,
        ComplaintUpdated,
        AttachmentUploaded,
        RoleAssigned,
        RoleRevoked,
        UserCreated,
        UserUpdated,
        SettingsChanged,
        DataExported,
        DossierGenerated,
        RewardDecisionMade,
        RewardPaid
    }

}
