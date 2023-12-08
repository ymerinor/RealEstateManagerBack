using RealEstateManager.Application.Property.Dto;

namespace RealEstateManager.UnitTest.System.Fixtures
{
    public class PropertyFixtures
    {
        public static PropertyRequestDto PropertyRequestDtoTest => new()
        {
            Address = "17141 COLLINS AVE #2601,SUNNY ISLES BEACH,FL 33160",
            Bathrooms = 1,
            Bedrooms = 2,
            City = "Miami",
            CodeInternal = "COD-1234",
            Country = "USA",
            Details = "Muse Residences 2601 this spacious full-floor residence boasts 4 bed, 5.1 bath plus office , and spans 6,000 square feet",
            IdOwner = 1,
            IdPropertyType = 1,
            Name = "Unidad 2035",
            Status = Application.Common.PropertysStatusEnum.Activo,
            Year = 2019
        };
    }
}
