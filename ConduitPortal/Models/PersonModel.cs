using FjtFramework.Cores;

namespace ConduitPortal.Models
{
    public class PersonModel : BaseEntity
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Bio { get; set; }

        public string Image { get; set; }
    }
}
