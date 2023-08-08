namespace Application.DTO
{

    public record PatientDto(int id, string name, string address, int age, List<InjuryDto> Injury);

}
