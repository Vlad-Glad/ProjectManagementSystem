using System;

public interface IUnitOfWork : IDisposable
{
    IProjectRepository Projects { get; }
    ITaskRepository Tasks { get; }

    void BeginTransaction();
    void Commit();
    void Rollback();
}
