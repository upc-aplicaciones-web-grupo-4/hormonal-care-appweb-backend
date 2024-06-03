namespace AppWeb.HormonalCare.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}