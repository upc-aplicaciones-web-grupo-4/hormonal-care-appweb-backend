﻿namespace AppWeb.HormonalCare.API.MedicalRecord.Interfaces.REST.Resources;

public record CreateMedicationResource( int PrescriptionId, int MedicationTypeId, string DrugName, int Quantity, string Concentration, int Frequency, string Duration);