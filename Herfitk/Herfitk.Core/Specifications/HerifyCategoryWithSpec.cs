using Herfitk.Core.Models.Data;

namespace Herfitk.Core.Specifications
{
    public class HerifyCategoryWithSpec : Specification<HerifyCategory>
    {
        public HerifyCategoryWithSpec()
        {
            Includes.Add(e => e.Herify);
            Includes.Add(e => e.Herify.HerfiyUser);
        }
    }
}