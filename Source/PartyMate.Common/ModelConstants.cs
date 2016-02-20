namespace PartyMate.Common
{
    public class ModelConstants
    {
        public const string ValidatorRegexUrl = @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
        public const string ValidatorRegexEmail = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        public const string ValidatorRegexFacebook = @"(?:https?:\/\/)?(?:www\.)?facebook\.com\/(?:(?:\w)*#!\/)?(?:pages\/)?(?:[\w\-]*\/)*([\w\-\.]*)";
        public const string ValidatorRegexTwitter = @"(?:http:\/\/)?(?:https?:\/\/)?(?:www\.)?twitter\.com\/(?:(?:\w)*#!\/)?(?:pages\/)?(?:[\w\-]*\/)*([\w\-]*)";

        public const int UserFirstNameMinLength = 3;
        public const int UserFirstNameMaxLength = 10;
        public const int UserLastNameMinLength = 3;
        public const int UserLastNameMaxLength = 10;

        public const int EventTitleMinLength = 4;
        public const int EventTitleMaxLength = 15;
        public const int EventDescriptionMinLength = 10;
        public const int EventDescriptionMaxLength = 500;
        public const int EventCommentContentMinLength = 2;
        public const int EventCommentContentMaxLength = 200;
        public const int EventMinEntranceFee = 0;

        public const int ClubNameMinLength = 2;
        public const int ClubNameMaxLength = 15;
        public const int ClubAdressMinLength = 5;
        public const int ClubAdressMaxLength = 15;
        public const int ClubPhoneMinLength = 5;
        public const int ClubReviewContentMinLength = 5;
        public const int ClubReviewContentMaxLength = 500;
    }
}
