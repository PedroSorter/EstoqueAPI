using Dados;
using EstoqueAPI.Infraestrutura;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace EstoqueAPI
{
  public class UnitOfWork<TContext> : IUnitOfWork, IDisposable
           where TContext : Contexto
  {
    // Flag: Has Dispose already been called?
    bool disposed = false;
    // Instantiate a SafeHandle instance.
    readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

    public Contexto Contexto { get; set; }

    public UnitOfWork(TContext context)
    {
      Contexto = context;
    }
    public async Task Commit()
    {
      await Contexto.SaveChangesAsync();
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
      if (disposed)
        return;

      if (disposing)
      {
        handle.Dispose();
        Contexto.Dispose();
      }

      disposed = true;
    }

  }
}
