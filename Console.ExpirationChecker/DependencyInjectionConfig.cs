﻿namespace QOAM.Console.ExpirationChecker
{
    using System;

    using Autofac;

    using QOAM.Core.Repositories;
    using QOAM.Core.Services;

    internal static class DependencyInjectionConfig
    {
        internal static IContainer RegisterComponents()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(JournalRepository).Assembly)
                   .Where(IsRepositoryType)
                   .AsImplementedInterfaces()
                   .SingleInstance();

            builder.RegisterType<ApplicationDbContext>().SingleInstance();
            builder.RegisterType<ExpirationChecker>().SingleInstance();
            builder.RegisterType<ExpirationCheckerNotification>().SingleInstance();
            builder.Register(_ => ExpirationCheckerSettings.Current).As<ExpirationCheckerSettings>().SingleInstance();
            builder.Register(c => new MailSender(c.Resolve<ExpirationCheckerSettings>().SmtpHost)).As<IMailSender>().SingleInstance();

            return builder.Build();
        }

        private static bool IsRepositoryType(Type t)
        {
            return t.Name.EndsWith("Repository");
        }
    }
}