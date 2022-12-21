using IronicBotCore.Models;

namespace IronicBotCore.Repositories
{
    internal class IdentityRepository
    {
        private List<Identity> identities;

        public IdentityRepository()
        {
            identities = new List<Identity>
              {

              new Identity { Id = Guid.NewGuid(),Name="email",Pattern= new System.Text.RegularExpressions.Regex("\\A([^@\\s]+)@((?:[-a-z0-9]+\\.)+[a-z]{2,})\\Z")},
              new Identity { Id = Guid.NewGuid(),Name="bilhete",Pattern= new System.Text.RegularExpressions.Regex("\\A([0-9]{9})([A-Z]{2})([0-9]{3})\\Z")},
              new Identity { Id = Guid.NewGuid(),Name="phone",Pattern= new System.Text.RegularExpressions.Regex("^\\+?[1-9][0-9]{7,14}$")},
              new Identity { Id = Guid.NewGuid(),Name="any",Pattern= new System.Text.RegularExpressions.Regex("")},
              new Identity { Id = Guid.NewGuid(),Name="number",Pattern= new System.Text.RegularExpressions.Regex("^\\d+$")},
              new Identity { Id = Guid.NewGuid(),Name="date",Pattern= new System.Text.RegularExpressions.Regex("^[0-9]{1,2}\\/[0-9]{1,2}\\/[0-9]{4}$")},
            };
        }
        public Identity? Get(string name)
        {
            return identities?.FirstOrDefault(x => x.Name == name);
        }
        public Identity? Get(Guid id)
        {
            return identities?.FirstOrDefault(x => x.Id == id);
        }
    }
}
