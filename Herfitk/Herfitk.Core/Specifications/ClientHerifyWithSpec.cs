using Herfitk.Core.Models.Data;

namespace Herfitk.Core.Specifications
{
    public class ClientHerifyWithSpec : Specification<ClientHerify>
    {
        public ClientHerifyWithSpec() => Includes.Add(e => e.Client.ClientUser);

        public ClientHerifyWithSpec(int id) : base(e => e.Id == id) => Includes.Add(e => e.Client.ClientUser);
    }
}