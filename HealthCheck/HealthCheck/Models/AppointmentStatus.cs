namespace HealthCheck.Models
{
    public enum AppointmentStatus
    {
        PendingApproval,
        Approved,
        CancelledByClient,
        CancelledByOrganization,
        Completed,
        NoShow
    }
}
