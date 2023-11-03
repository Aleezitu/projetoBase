using FluentAssertions;
using HelperStockBeta.Domain.Entities;

namespace HelpStockBeta.Domain.Test
{
    #region Testes Positivos
    public class ProductUnitTestBase
    {
        [Fact(DisplayName = "Product name is not null")]
        public void CreateProduct_whithValidParameters_ResultValid()
        {
            Action action = () => new Product(1, "Product name", "Product description", 1, 1, "Product img");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();

        }
        [Fact(DisplayName = "Product not present id parameter.")]
        public void CreateProduct_IdParameter_ResultValid()
        {
            Action action = () => new Product("Product name", "Product description", 1, 1, "Product img");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();

        }
    #endregion

     #region Testes negativos
        [Fact(DisplayName = "Id negative exception")]
        public void CreateProduct_Negative_NegativeParameterId_ResutException()
        {
            Action action = () => new Product(-1, "Product name", "Product description", -1, -1, "Product img");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid negative values for id.");

        }

        [Fact(DisplayName = "Name in Category null.")]
        public void CreateProduct_NameParameter_ResutException()
        {
            Action action = () => new Product(1, null, "Product description", 1, 1, "Product img");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");

        }

        [Fact(DisplayName = "Product name is short")]
        public void CreateProduct_NameParameterShort_ResutException()
        {
            Action action = () => new Product(1, "Pr", "Product description", 1, 1, "Product img");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid short names, minimum 3 characteres.");

        }

        [Fact(DisplayName = "Product description is required")]
        public void CreateProduct_DescriptionParameterRequired_ResutException()
        {
            Action action = () => new Product(1, "Product name", null, 1, 1, "Product img");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required.");

        }

        [Fact(DisplayName = "Product description is short")]
        public void CreateProduct_DescriptionParameterShort_ResutException()
        {
            Action action = () => new Product(1, "Product name", "Prod", 1, 1, "Product img");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid short descriptions, minimum 5 characters.");

        }

        [Fact(DisplayName = "Product price is negative")]
        public void CreateProduct_PriceParameterNegative_ResutException()
        {
            Action action = () => new Product(1, "Product name", "Product description", -1, 1, "Product img");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid negative values for price.");

        }

        [Fact(DisplayName = "Product value for stock is negative")]
        public void CreateProduct_ValueParameterNegative_ResutException()
        {
            Action action = () => new Product(1, "Product name", "Product description", 1, -1, "Product img");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid negative values for stock.");

        }

        [Fact(DisplayName = "Product Url is long")]
        public void CreateProduct_UrlParameterLong_ResutException()
        {
            Action action = () => new Product(1, "Product name", "Product description", 1, 1, "Maecenas ipsum velit, consectetuer eu, lobortis ut, dictum at, dui. In rutrum. Sed ac dolor sit amet purus malesuada congue. In laoreet, magna id viverra tincidunt, sem odio bibendum justo, vel imperdiet sapien wisi sed libero. Suspendisse sagittis ultrices");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid long URL, maximum 250 characteres.");

        }
        #endregion
    }
}