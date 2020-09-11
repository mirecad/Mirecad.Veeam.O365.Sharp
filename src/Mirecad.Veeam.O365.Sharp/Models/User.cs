using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;

namespace Mirecad.Veeam.O365.Sharp.Models
{
    [DataTransferObject(typeof(UserDto))]
    public class User
    {
        //TODO:Implement user links
        //private VeeamLink<OrganizationDto> _linksOrganization;
        //private VeeamLink<VeeamPagedResultDto<OneDriveDto>> _linksOneDrives;

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsBackedUp { get; set; }
    }
}