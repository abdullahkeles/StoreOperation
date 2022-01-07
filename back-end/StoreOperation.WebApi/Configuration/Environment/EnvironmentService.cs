﻿using System;
using Microsoft.Extensions.Configuration;

namespace StoreOperation.WebApi.Configuration.Environment
{
    public class EnvironmentService : IEnvironmentService
    {
        private static IConfiguration _configuration;
        public IConfiguration Configuration => _configuration;
        
        private static string _environmentVariableValue = "";
        private static string _environmentVariableKey = "KELESLER_CHECKLIST_ENVIRONMENT";

        public EnvironmentService()
        {
            SetEnvironmentValue();
            SetConfiguration();
        }
        private static void SetConfiguration()
        {
            if (_configuration == null)
            {
                var configurationBuilder = new ConfigurationBuilder();

                var appsettingsFileName = $"Configuration/appsettings.{_environmentVariableValue.ToLower()}.json";

                _configuration = configurationBuilder.SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile(appsettingsFileName, optional: false, reloadOnChange: true)
                    .Build();
            }
        }
        private static void SetEnvironmentValue()
        {
            // profil dosyasından KELESLER_CHECKLIST_ENVIRONMENT değişkeninin değerini alıyoruz
            _environmentVariableValue = System.Environment.GetEnvironmentVariable(_environmentVariableKey, EnvironmentVariableTarget.Process);
            //System.Environment.GetEnvironmentVariable("KELESLER_CHECKLIST_ENVIRONMENT", EnvironmentVariableTarget.Process);

            if (_environmentVariableValue == null)
            {
                throw new ArgumentException($"{_environmentVariableKey} environment can not be null!");
            }
        }
        

        /// <summary>
        /// Static configuration instance. You can use this property without `new` keyword.
        /// </summary>
        public static IConfiguration StaticConfiguration
        {
            get
            {
                if (_configuration == null)
                {
                    SetEnvironmentValue();
                    SetConfiguration();
                }

                return _configuration;
            }
        }

        public bool IsDevelopment => _environmentVariableValue.ToLower() == "development";
        public bool IsTest => _environmentVariableValue.ToLower() == "test";
        public bool IsProduction => _environmentVariableValue.ToLower() == "production";
    }
}