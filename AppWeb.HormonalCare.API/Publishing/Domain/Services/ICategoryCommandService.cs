using AppWeb.HormonalCare.API.Publishing.Domain.Model.Commands;
using AppWeb.HormonalCare.API.Publishing.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.Publishing.Domain.Services;

public interface ICategoryCommandService
{
    public Task<Category?> Handle(CreateCategoryCommand command);
}