using RealEstateManager.Application.Common;
using RealEstateManager.Application.Propertys.Dto;
using RealEstateManager.Domain.Owners;
using RealEstateManager.Domain.PropertyImages;
using RealEstateManager.Domain.Propertys;
using RealEstateManager.Domain.PropertyTypes;

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
            PropertyType = 1,
            Name = "Unidad 2035",
            Status = PropertysStatusEnum.Activo,
            Year = 2019
        };

        public static PropertyRequestDto PropertyRequestBadRequestDtoTest => new()
        {
            Address = "17141 COLLINS AVE #2601,SUNNY ISLES BEACH,FL 33160",
            Bathrooms = 1,
            Bedrooms = 2,
            CodeInternal = "COD-1234",
            IdOwner = 1,
            PropertyType = 1,
            Year = 2019,
            Price = 1000
        };

        public static Property PropertySemillaTest => new()
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
            CreateDate = DateTime.Now,
            Status = PropertysStatusEnum.Activo.ToString(),
            Year = 2020
        };

        public static PropertyDto PropertyDto => new()
        {
            IdProperty = 1,
            Address = "17141 COLLINS AVE #2601,SUNNY ISLES BEACH,FL 33160",
            Bathrooms = 1,
            Bedrooms = 2,
            City = "Miami",
            CodeInternal = "COD-1234",
            Country = "USA",
            Details = "Muse Residences 2601 this spacious full-floor residence boasts 4 bed, 5.1 bath plus office , and spans 6,000 square feet",
            IdOwner = 1,
            PropertyType = 1,
            Name = "Unidad 2035",
            CreateDate = DateTime.Now,
            Status = PropertysStatusEnum.Activo.ToString(),
            Year = 2020
        };

        public static Property PropertyTest => new()
        {
            IdProperty = 1,
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
            CreateDate = DateTime.Now,
            Status = PropertysStatusEnum.Activo.ToString(),
            Year = 2020,
            Owner = new Owner { IdOwner = 1, Name = "Cristian Rodrigues" },
            PropertyType = new PropertyType { IdPropertyType = 1, Name = "Residencial" },
            LastModified = DateTime.Now,
            Price = 100,
            PropertyImages = new List<PropertyImage>()
        };

        public static Property PropertyCreateTest => new()
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
            CreateDate = DateTime.Now,
            Status = PropertysStatusEnum.Activo.ToString(),
            Year = 2020,
            Price = 100,
            LastModified = DateTime.Now,

        };

        public static Owner OwnerCreateTest => new()
        {
            IdOwner = 1,
            Address = "Calle 10 via al mar",
            City = "Miami",
            Country = "USA",
            Name = "Name",
            Phone = "8978888",
            Birthday = DateTime.Now
        };

        public static PropertyType PropertyTypeCreateTest => new()
        {
            IdPropertyType = 1,
            Name = "Residencial",
            Enabled = true,
            CreateDate = DateTime.Now,
            LastModified = DateTime.Now
        };
        public static PropertyImage PropertyImageTest => new()
        {
            IdProperty = 1,
            IdPropertyImage = 1,
            FilePath = "C://Nueva_Ruta",
            Enabled = true
        };
    }
}
