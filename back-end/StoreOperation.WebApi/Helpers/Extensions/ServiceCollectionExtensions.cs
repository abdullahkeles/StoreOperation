using Microsoft.Extensions.DependencyInjection;
using StoreOperation.WebApi.ActionFilters;
using StoreOperation.WebApi.Configuration.Context;
using StoreOperation.WebApi.Configuration.Environment;
using StoreOperation.WebApi.Data.Repositories;
using StoreOperation.WebApi.Data.Repositories.Abstract;
using StoreOperation.WebApi.Services;
using StoreOperation.WebApi.Services.Abstract;
using StoreOperation.WebApi.Utilities.Email;
using StoreOperation.WebApi.Utilities.Email.SmtpMail;
using StoreOperation.WebApi.Utilities.File;
using StoreOperation.WebApi.Utilities.File.Local;
using StoreOperation.WebApi.Utilities.Security.Hash;
using StoreOperation.WebApi.Utilities.Security.Token;
using StoreOperation.WebApi.Utilities.Security.Token.Jwt;

namespace StoreOperation.WebApi.Helpers.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILoggerRepository, LoggerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAppStoreRepository, AppStoreRepository>();
            services.AddScoped<ICheckListDayRepository, CheckListDayRepository>();
            services.AddScoped<ICheckListQuestionGroupsRepository, CheckListQuestionGroupsRepository>();
            services.AddScoped<ICheckListQuestionRepository, CheckListQuestionRepository>();
            services.AddScoped<ICheckListQuestionAnswerRepository, CheckListQuestionAnswerRepository>();
            services.AddScoped<ICheckListRepository, CheckListRepository>();
            return services;
        }

        public static IServiceCollection RegisterUtility(this IServiceCollection services)
        {
            services.AddSingleton<TokenAuthentication>();
            services.AddScoped<IMailService, SmtpMailService>();
            services.AddScoped<IFileService, LocalFileService>();
            services.AddSingleton<ITokenService, JwtTokenService>();
            services.AddSingleton<IHashService, Sha256HashService>();
            services.AddSingleton<IStoreOperationConfigurationContext, StoreOperationConfigurationContext>();
            services.AddSingleton<IEnvironmentService, EnvironmentService>();
            return services;

        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAppStoreService, AppStoreService>();
            services.AddScoped<IAppStoreService, AppStoreService>();
            services.AddScoped<ICheckListService, CheckListService>();
            services.AddScoped<ICheckListStoreReportService, CheckListStoreReportService>();
            services.AddScoped<ICheckListAppReportService, CheckListAppReportService>();
            return services;

        }

    }
}