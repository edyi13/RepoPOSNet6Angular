namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        //se declara o matricula las interfaces a nivel de repositorio
        ICategoryRepository Category{ get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
