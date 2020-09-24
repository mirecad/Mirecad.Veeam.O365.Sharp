﻿using System.Threading;
using System.Threading.Tasks;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Attributes;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;

namespace Mirecad.Veeam.O365.Sharp.Objects.Domain
{
    [DataTransferObject(typeof(ProxyDto))]
    public class Proxy : ProxyDto
    {
        private VeeamLink<VeeamCollectionResult<BackupRepository>> _linksRepositories;

        public async Task<VeeamCollectionResult<BackupRepository>> GetBackupRepositoriesAsync(CancellationToken ct = default)
            => await _linksRepositories.InvokeAsync(ct);
    }
}