using Mirecad.Veeam.O365.Sharp.Clients;

namespace Mirecad.Veeam.O365.Sharp
{
    public interface IVeeamO365Client
    {
        IJobClient Jobs { get; }
        IMailboxClient Mailboxes { get; }
        IOneDriveClient OneDrives { get; }
        IOrganizationClient Organizations { get; }
        IOrganizationUserClient OrganizationUsers { get; }
        IOrganizationSiteClient OrganizationSites { get; }
        IOrganizationGroupClient OrganizationGroups { get; }
        IBackupRepositoryClient BackupRepositories { get; }
        ISharePointClient SharePoints { get; }
        ILicensedUserClient LicensedUsers { get; }
    }
}