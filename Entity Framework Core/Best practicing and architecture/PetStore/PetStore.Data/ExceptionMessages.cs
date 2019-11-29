namespace PetStore.Data
{
    public static class ExceptionMessages
    {
        public static class BrandExceptions
        {
            public const string NameLengthException = "Brand name must be equal or less than 30 symbols long!";

            public const string NameNullOrEmptyException = "Brand name can not be null, empty or white space!";

            public const string ExistingBrand = "Brand with given name already exists in the database!";

            public const string NotExistingBrand = "Brand with given name does not exists in the database!";
        }

        public static class ToyExceptions
        {
            public const string NameLengthException = "Toy name must be less or equal to 30 symbols!";

            public const string NameNullOrEmptyException = "Toy name can not be null, empty or white space!";

            public const string PriceException = "Toy price should not be negative number or zero!";

            public const string NotExistingToy = "Toy with given name does not exists in the database!";
        }

        public static class FoodExceptions
        {
            public const string NameLengthException = "Food name must be less or equal to 20 symbols!";

            public const string NameNullOrEmptyException = "Food name can not be null, empty or white space!";

            public const string PriceException = "Food price should not be negative number or zero!";

            public const string WeightException = "Food weight should not be negative number or zero!";

            public const string NotExistingFood = "Food with given name does not exists in the database!";
        }

        public static class CategoryExceptions
        {
            public const string NameLengthException = "Category name must be less or equal to 20 symbols!";

            public const string NameNullOrEmptyException = "Category name can not be null, empty or white space!";

            public const string ExistingCategory = "Category with given name already exists in the database!";

            public const string NotExistingCategory = "Category with given name does not exists in the database!";
        }

        public static class OrderExceptions
        {
            public const string NameLengthException = "Order name must be less or equal to 20 symbols!";

            public const string NameNullOrEmptyException = "Order name can not be null, empty or white space!";

            public const string ExistingOrderException = "Order with given name already exists in the database!";

            public const string NotExistingOrderException = "Order with given name does not exists in the database!";
        }

        public static class UserExceptions
        {
            public const string NameLengthException = "User name must be less than or equal to 100 symbols!";

            public const string NameNullOrEmptyException = "User name can not be null, empty or white space!";

            public const string NotExistingUserException = "User with given name does not exists in the database!";

            public const string ExistingUserException = "User with given name already exists in the database!";

            public const string EmailLengthException = "User email can not be more than 50 symbols!";

            public const string EmailNullOrWhiteSpaceException = "User email can not be null, empty or white space!";
        }

        public static class BreedExceptions
        {
            public const string NameLengthException = "Breed name must be less or equal to 50 symbols!";

            public const string NameNullOrEmptyException = "Breed name can not be null, empty or white space!";

            public const string ExistingBreedException = "Breed with given name already exists in the database!";

            public const string NotExistingBreedException = "Breed with given name does not exists in the database!";
        }

        public static class PetExceptions
        {
            public const string NameLengthException = "Pet name must be less or equal to 50 symbols!";

            public const string NameNullOrEmptyException = "Pet name can not be null, empty or white space!";

            public const string ExistingPetException = "Pet with given name already exists in the database!";

            public const string NotExistingPetException = "Pet with given name does not exists in the database!";
        }



    }
}
