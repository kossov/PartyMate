namespace PartyMate.Common
{
    public class GlobalConstants
    {
        public const string AdministratorRoleName = "Administrator";
        public const string AdministratorFirstName = "Admin";
        public const string AdministratorLastName = "Admin";
        public const string AdministratorUserName = "admin@admin.com";
        public const string AdministratorPassword = AdministratorUserName;

        public const string UserRoleName = "User";

        // TODO: extract those into a generic '{0} path is not valid'
        public const string UrlIsNotValid = "Url path is not valid!";
        public const string EmailIsNotValid = "Email not valid!";
        public const string FacebookIsNotValid = "Facebook path is not valid!";
        public const string TwitterIsNotValid = "Twitter path is not valid!";

        public const int DefaultPageSize = 10;
        public const double ClubInRangeRadius = 00.002;

        public const int AnonymousReviewContentMinLength = 5;
        public const int AnonymousReviewContentMaxLength = 200;
    }
}
