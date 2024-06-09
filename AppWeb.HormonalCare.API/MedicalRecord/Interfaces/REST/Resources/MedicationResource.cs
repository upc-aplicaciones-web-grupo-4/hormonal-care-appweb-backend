using AppWeb.HormonalCare.API.MedicalRecord.Domain.Model.Entities;

namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record MedicationResource(
    int Id, PrescriptionResource PrescriptionId, MedicationTypeResource MedicationTypeId, string DrugName, int Quantity, string Concentration, int Frequency, string Duration
    );