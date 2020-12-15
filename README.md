# Mirecad.Veeam.O365.Sharp
C# REST API wrapper for Veeam Backup for Microsoft Office 365

[Veeam Backup for Microsoft Office 365](https://go.veeam.com/backup-office-365)

[Rest API doc](https://helpcenter.veeam.com/docs/vbo365/rest/vbo_rest_api_reference.html?ver=50)

**Library is under construction...**

## How to use
```csharp
var options = new VeeamO365ClientOptions(
  new Uri("https://server:4443"),
  @"DOMAIN\username",
  "password".ToSecureString(),
  TimeSpan.FromMinutes(20)); //HTTP call timeout. If you want to download large backup files, set this attribute to high value.
  
using var client = VeeamO365Client.CreateAuthenticatedClient(options);

var organizations = await client.Organizations.GetOrganizations();
var jobs = await organizations.First().GetJobsAsync();
var sampleJob = jobs.First();

//you can always manipulate with objects by calling client
await client.Jobs.StartJobAsync(sampleJob.Id);
//sometimes you can achieve the same thing by calling method on given object
await sampleJob.StartJobAsync();

```
