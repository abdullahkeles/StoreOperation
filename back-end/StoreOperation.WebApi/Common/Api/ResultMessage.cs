namespace StoreOperation.WebApi.Common.Api
{
    /// <summary>
    /// It provides global result message keys.
    /// </summary>
    public static class ResultMessage
    {
        public static string Success => "messages.success.general.ok";
        public static string SuccessUpdate => "messages.success.update.ok";
        public static string InvalidModel => "messages.error.general.invalidModel";
        public static string UnhandledException => "messages.error.general.unhandledException";
        public static string UnAuthorized => "messages.error.general.unAuthorized";
        public static string Forbidden => "messages.error.general.Forbidden";
        public static string InternalServerError => "messages.error.general.internalServerError";
        public static string TokenCanNotBeEmptyOrNull => "messages.error.token.tokenCanNotBeEmptyOrNull";
        public static string CheckListQuestionGroupNameCanNotBeEmptyOrNull => "messages.error.checklist.checklistquestiongroupnameCanNotBeEmptyOrNull";
        public static string CheckListQuestionIdAndGroupIdCanNotBeEmptyOrNull => "Sorunun id veya group id propertisi boş olamaz.";
        public static string CheckListQuestionIdCanNotBeEmpty => "sorunun id bilgisi olmadan pasife çekilemez";
        public static string CheckListQuestionNotPassive => "sorunun id bilgisi olmadan pasife çekilemez";
        public static string CheckListQuestionGroupIdCanNotBeEmpty => "messages.error.checklist.CheckListQuestionGroupIdCanNotBeEmpty";
        public static string CheckListQuestionGroupCreate => "messages.success.checklist.CheckListQuestionGroupCreate";
        public static string TokenMustStartWithBearerKeyword => "messages.error.token.tokenMustStartWithBearerKeyword";
        public static string InvalidToken => "messages.error.token.invalidToken";
        public static string NotFoundUser => "messages.error.user.notFoundUser";
        public static string HasNotStore => "messages.error.user.HasNotStore";
        public static string InvalidSecurityKey => "messages.error.user.invalidSecurityKey";
        public static string InvalidProfileImage => "messages.error.user.invalidProfileImage";
        public static string InvalidProfileImageSize => "messages.error.user.invalidProfileImageSize";
        public static string ProfileImageCanNotBeNullOrEmpty => "messages.error.user.profileImageCanNotBeNullOrEmpty";
        public static string UserNameIsNotValidated => "messages.error.user.userNameIsNotValidated";
        public static string UserDoesNotHaveStoreId => "messages.error.user.UserDoesNotHaveStoreId";
        public static string InvalidUserNameOrPassword => "messages.error.user.invalidUserNameOrPassword";
        public static string SecurityKeyExpiryDateAlreadyExpired => "messages.error.user.securityKeyExpiryDateAlreadyExpired";
        public static string UserPasswordChanged => "messages.success.user.UserPasswordChanged";
        public static string VerificationEmailSent => "messages.success.user.VerificationEmailSent";
        public static string UserUpdate => "messages.success.user.UserUpdate";
        public static string UserRegistered => "messages.success.user.UserRegistered";
        public static string EmptyStoreId => "messages.error.store.emptyStoreId";
        public static string RemovedStore => "messages.error.store.removedStore";
        public static string NotRemovedStore => "messages.error.store.notRemovedStore";
        public static string NotRemoveQuestionsInGroups => "Soru grubuna id soru veya soruların id bilgisi yok.";
    }
}
