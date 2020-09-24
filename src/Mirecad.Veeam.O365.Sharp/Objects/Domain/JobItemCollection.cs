using System.Collections.Generic;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(JobItemCollectionDto))]
    public class JobItemCollection
    {
        public List<SiteJobItem> Sites { get; set; } = new List<SiteJobItem>();
        public List<PartialOrganizationJobItem> PartialOrganizations { get; set; } = new List<PartialOrganizationJobItem>();
        public List<UserJobItem> Users { get; set; } = new List<UserJobItem>();
        public List<GroupJobItem> Groups { get; set; } = new List<GroupJobItem>();

        public void AddUser(OrganizationUser user, bool mailbox, bool oneDrive, bool archiveMailbox, bool site)
        {
            var userJobItem = new UserJobItem
            {
                Type = "User",
                User = user,
                Mailbox = mailbox,
                OneDrive = oneDrive,
                ArchiveMailbox = archiveMailbox,
                Site = site
            };
            Users.Add(userJobItem);
        }

        public void AddPartialOrganization(bool mailbox, bool oneDrive, bool archiveMailbox, bool site)
        {
            var partialOrganizationJobItem = new PartialOrganizationJobItem
            {
                Type = "PartialOrganization",
                Mailbox = mailbox,
                OneDrive = oneDrive,
                ArchiveMailbox = archiveMailbox,
                Site = site
            };
            PartialOrganizations.Add(partialOrganizationJobItem);
        }

        public void AddSite(OrganizationSite site)
        {
            var siteJobItem = new SiteJobItem
            {
                Type = "Site",
                Site = site
            };
            Sites.Add(siteJobItem);
        }

        public void AddGroup(OrganizationGroup group, bool members, bool memberMail, bool memberArchive, bool memberOnedrive, bool memberSite, bool mail, bool site)
        {
            var groupJobItem = new GroupJobItem
            {
                Type = "Group",
                Group = group,
                Members = members,
                MemberMail = memberMail,
                MemberArchive = memberArchive,
                MemberOnedrive = memberOnedrive,
                MemberSite = memberSite,
                Mail = mail,
                Site = site
            };
            Groups.Add(groupJobItem);
        }
    }
}