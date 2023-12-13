namespace SoftUniBazar.Constants
{
    public static class EntityValidationConstants
    {
        public static class Ad
        {
            public const string AdPriceColumnType = "decimal(18, 6)";
            public const int NameMinLength = 5;
            public const int NameMaxLength = 25;
            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 250;
        }
        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 15;
        }
    }
}
