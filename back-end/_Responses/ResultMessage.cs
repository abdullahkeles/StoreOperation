namespace StoreOperation.WebApi.Common
{
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
        public static string TokenMustStartWithBearerKeyword => "messages.error.token.tokenMustStartWithBearerKeyword";
        public static string InvalidToken => "messages.error.token.invalidToken";
        public static string NotFoundUser => "messages.error.user.notFoundUser";
        public static string InvalidSecurityKey => "messages.error.user.invalidSecurityKey";
        public static string InvalidProfileImage => "messages.error.user.invalidProfileImage";
        public static string InvalidProfileImageSize => "messages.error.user.invalidProfileImageSize";
        public static string ProfileImageCanNotBeNullOrEmpty => "messages.error.user.profileImageCanNotBeNullOrEmpty";
        public static string UserNameIsNotValidated => "messages.error.user.userNameIsNotValidated";
        public static string UserDoesNotHaveStoreId => "messages.error.user.UserDoesNotHaveStoreId";
        public static string InvalidUserNameOrPassword => "messages.error.user.invalidUserNameOrPassword";
        public static string SecurityKeyExpiryDateAlreadyExpired => "messages.error.user.securityKeyExpiryDateAlreadyExpired";
        public static string EmptyStoreId => "messages.error.store.emptyStoreId";
        public static string RemovedStore => "messages.error.store.removedStore";
        public static string NotRemovedStore => "messages.error.store.notRemovedStore";
    }
}