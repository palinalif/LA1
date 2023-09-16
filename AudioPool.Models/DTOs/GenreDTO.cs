// DTO: What we return to the user, doesn't include all the stuff from the entity
namespace AudioPool.Models.DTOs
{
    public class GenreDTO : HyperMediaModel
    {
        public int id;
        public string? name;
    }
}   