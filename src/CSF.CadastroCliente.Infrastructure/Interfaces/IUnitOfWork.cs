﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSF.CadastroCliente.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
