namespace AppWeb.HormonalCare.API.Publishing.Domain.Model.ValueObjects;

public enum EPublishingStatus
{
    Draft,
    ReadyToEdit,
    ReadyToApproval,
    ApprovedAndLocked
}