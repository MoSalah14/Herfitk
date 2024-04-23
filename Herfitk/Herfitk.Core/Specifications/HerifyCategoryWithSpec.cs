using Herfitk.Core.Models.Data;

namespace Herfitk.Core.Specifications
{
    public class HerifyCategoryWithSpec : Specification<HerifyCategory>
    {
        public HerifyCategoryWithSpec(HerifySpecParam herifySpecParam)
        {
            Includes.Add(e => e.Herify);
            Includes.Add(e => e.Herify.HerfiyUser);
            Criteria = e => e.CategoryId == herifySpecParam.categoryId;

            ApplyPagination((herifySpecParam.PageIndex - 1) * herifySpecParam.PageSize, herifySpecParam.PageSize);
        }
    }
}