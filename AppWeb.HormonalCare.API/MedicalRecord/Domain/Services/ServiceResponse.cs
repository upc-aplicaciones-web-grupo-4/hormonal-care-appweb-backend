namespace AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;

public class ServiceResponse<T>
{
    public T Diagnostic { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }

    public ServiceResponse(T diagnostic)
    {
        Diagnostic = diagnostic;
        Success = true;
    }

    public ServiceResponse(string message)
    {
        Success = false;
        Message = message;
    }
}
