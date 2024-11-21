namespace SharedModels.Interface
{
    public interface IAccountLockout
    {
        int FailedLoginAttempts { get; set; }
        DateTime? LockoutEnd { get; set; }
    }
}
