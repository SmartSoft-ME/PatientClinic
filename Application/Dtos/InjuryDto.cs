namespace Application.DTO
{
   public record InjuryDto(int id, string type, string treatement, List<int> paids);
}
