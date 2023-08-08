namespace Application.DTO
{
   public record InjuryDto(int id, string type, string treatment, List<PatientDto> patients);
}
