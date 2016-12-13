// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 添加服务到 <see cref="IServiceCollection" /> 的扩展方法。
    /// </summary>
    public static class ServiceCollectionServiceExtensions
    {
        /// <summary>
        /// 添加一个类型为 <paramref name="serviceType"/> 的瞬时服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <paramref name="implementationType"/> 指定其实现类型。
        /// 
        /// </summary>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="serviceType">将注册的服务类型。</param>
        /// <param name="implementationType">服务的实现类型。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IServiceCollection AddTransient(
            this IServiceCollection services,
            Type serviceType,
            Type implementationType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            return Add(services, serviceType, implementationType, ServiceLifetime.Transient);
        }

        /// <summary>
        /// 添加一个类型为 <paramref name="serviceType"/> 的瞬时服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <paramref name="implementationFactory"/> 指定其实现的工厂。
        /// 
        /// </summary>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="serviceType">将注册的服务类型。</param>
        /// <param name="implementationFactory">创建服务的工厂。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IServiceCollection AddTransient(
            this IServiceCollection services,
            Type serviceType,
            Func<IServiceProvider, object> implementationFactory)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return Add(services, serviceType, implementationFactory, ServiceLifetime.Transient);
        }

        /// <summary>
        /// 添加一个类型为 <typeparamref name="TService"/> 的瞬时服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <typeparamref name="TImplementation"/> 指定其实现类型。
        /// 
        /// </summary>
        /// <typeparam name="TService">将添加的服务类型。</typeparam>
        /// <typeparam name="TImplementation">用来实现服务的类型。</typeparam>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddTransient(typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        /// 添加一个类型为 <paramref name="serviceType"/> 的瞬时服务到
        /// 指定 <see cref="IServiceCollection"/> 中。
        /// </summary>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="serviceType">用来注册和实现服务的类型。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IServiceCollection AddTransient(
            this IServiceCollection services,
            Type serviceType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            return services.AddTransient(serviceType, serviceType);
        }

        /// <summary>
        /// 添加一个类型为 <typeparamref name="TService"/> 的瞬时服务到
        /// 指定 <see cref="IServiceCollection"/> 中。
        /// </summary>
        /// <typeparam name="TService">将要添加的服务类型。</typeparam>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IServiceCollection AddTransient<TService>(this IServiceCollection services)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddTransient(typeof(TService));
        }

        /// <summary>
        /// 添加一个类型为 <typeparamref name="TService"/> 的瞬时服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <paramref name="implementationFactory"/> 指定其实现的工厂。
        /// 
        /// </summary>
        /// <typeparam name="TService">将添加的服务类型。</typeparam>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="implementationFactory">创建服务的工厂。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IServiceCollection AddTransient<TService>(
            this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddTransient(typeof(TService), implementationFactory);
        }

        /// <summary>
        /// 添加一个类型为 <typeparamref name="TService"/> 的瞬时服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <typeparamref name="TImplementation" /> 指定其实现类型，
        /// 由 <paramref name="implementationFactory"/> 指定其实现的工厂。
        /// 
        /// </summary>
        /// <typeparam name="TService">将添加的服务类型。</typeparam>
        /// <typeparam name="TImplementation">用来实现服务的类型。</typeparam>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="implementationFactory">创建服务的工厂。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IServiceCollection AddTransient<TService, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddTransient(typeof(TService), implementationFactory);
        }



        /// <summary>
        /// 添加一个类型为 <paramref name="serviceType"/> 的作用域服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <paramref name="implementationType"/> 指定其实现类型。
        /// 
        /// </summary>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="serviceType">将注册的服务类型。</param>
        /// <param name="implementationType">服务的实现类型。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IServiceCollection AddScoped(
            this IServiceCollection services,
            Type serviceType,
            Type implementationType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            return Add(services, serviceType, implementationType, ServiceLifetime.Scoped);
        }

        /// <summary>
        /// 添加一个类型为 <paramref name="serviceType"/> 的作用域服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <paramref name="implementationFactory"/> 指定其实现的工厂。
        /// 
        /// </summary>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="serviceType">将注册的服务类型。</param>
        /// <param name="implementationFactory">创建服务的工厂。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IServiceCollection AddScoped(
            this IServiceCollection services,
            Type serviceType,
            Func<IServiceProvider, object> implementationFactory)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return Add(services, serviceType, implementationFactory, ServiceLifetime.Scoped);
        }

        /// <summary>
        /// 添加一个类型为 <typeparamref name="TService"/> 的作用域服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <typeparamref name="TImplementation"/> 指定其实现类型。
        /// 
        /// </summary>
        /// <typeparam name="TService">将添加的服务类型。</typeparam>
        /// <typeparam name="TImplementation">用来实现服务的类型。</typeparam>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddScoped(typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        /// 添加一个类型为 <paramref name="serviceType"/> 的作用域服务到
        /// 指定 <see cref="IServiceCollection"/> 中。
        /// </summary>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="serviceType">用来注册和实现服务的类型。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IServiceCollection AddScoped(
            this IServiceCollection services,
            Type serviceType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            return services.AddScoped(serviceType, serviceType);
        }

        /// <summary>
        /// 添加一个类型为 <typeparamref name="TService"/> 的作用域服务到
        /// 指定 <see cref="IServiceCollection"/> 中。
        /// </summary>
        /// <typeparam name="TService">将要添加的服务类型。</typeparam>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IServiceCollection AddScoped<TService>(this IServiceCollection services)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddScoped(typeof(TService));
        }

        /// <summary>
        /// 添加一个类型为 <typeparamref name="TService"/> 的作用域服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <paramref name="implementationFactory"/> 指定其实现的工厂。
        /// 
        /// </summary>
        /// <typeparam name="TService">将添加的服务类型。</typeparam>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="implementationFactory">创建服务的工厂。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IServiceCollection AddScoped<TService>(
            this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddScoped(typeof(TService), implementationFactory);
        }

        /// <summary>
        /// 添加一个类型为 <typeparamref name="TService"/> 的作用域服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <typeparamref name="TImplementation" /> 指定其实现类型，
        /// 由 <paramref name="implementationFactory"/> 指定其实现的工厂。
        /// 
        /// </summary>
        /// <typeparam name="TService">将添加的服务类型。</typeparam>
        /// <typeparam name="TImplementation">用来实现服务的类型。</typeparam>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="implementationFactory">创建服务的工厂。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IServiceCollection AddScoped<TService, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddScoped(typeof(TService), implementationFactory);
        }


        /// <summary>
        /// 添加一个类型为 <paramref name="serviceType"/> 的单例服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <paramref name="implementationType"/> 指定其实现类型。
        /// 
        /// </summary>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="serviceType">将注册的服务类型。</param>
        /// <param name="implementationType">服务的实现类型。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton(
            this IServiceCollection services,
            Type serviceType,
            Type implementationType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            return Add(services, serviceType, implementationType, ServiceLifetime.Singleton);
        }

        /// <summary>
        /// 添加一个类型为 <paramref name="serviceType"/> 的单例服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <paramref name="implementationFactory"/> 指定其实现的工厂。
        /// 
        /// </summary>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="serviceType">将注册的服务类型。</param>
        /// <param name="implementationFactory">创建服务的工厂。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton(
            this IServiceCollection services,
            Type serviceType,
            Func<IServiceProvider, object> implementationFactory)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return Add(services, serviceType, implementationFactory, ServiceLifetime.Singleton);
        }

        /// <summary>
        /// 添加一个类型为 <typeparamref name="TService"/> 的单例服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <typeparamref name="TImplementation"/> 指定其实现类型。
        /// 
        /// </summary>
        /// <typeparam name="TService">将添加的服务类型。</typeparam>
        /// <typeparam name="TImplementation">用来实现服务的类型。</typeparam>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddSingleton(typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        /// 添加一个类型为 <paramref name="serviceType"/> 的单例服务到
        /// 指定 <see cref="IServiceCollection"/> 中。
        /// </summary>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="serviceType">用来注册和实现服务的类型。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton(
            this IServiceCollection services,
            Type serviceType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            return services.AddSingleton(serviceType, serviceType);
        }

        /// <summary>
        /// 添加一个类型为 <typeparamref name="TService"/> 的单例服务到
        /// 指定 <see cref="IServiceCollection"/> 中。
        /// </summary>
        /// <typeparam name="TService">将要添加的服务类型。</typeparam>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton<TService>(this IServiceCollection services)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddSingleton(typeof(TService));
        }

        /// <summary>
        /// 添加一个类型为 <typeparamref name="TService"/> 的单例服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <paramref name="implementationFactory"/> 指定其实现的工厂。
        /// 
        /// </summary>
        /// <typeparam name="TService">将添加的服务类型。</typeparam>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="implementationFactory">创建服务的工厂。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton<TService>(
            this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddSingleton(typeof(TService), implementationFactory);
        }

        /// <summary>
        /// 添加一个类型为 <typeparamref name="TService"/> 的单例服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <typeparamref name="TImplementation" /> 指定其实现类型，
        /// 由 <paramref name="implementationFactory"/> 指定其实现的工厂。
        /// 
        /// </summary>
        /// <typeparam name="TService">将添加的服务类型。</typeparam>
        /// <typeparam name="TImplementation">用来实现服务的类型。</typeparam>
        /// <param name="services">用来实现服务的类型。</param>
        /// <param name="implementationFactory">创建服务的工厂。</param>
        /// <returns>创建服务的工厂。</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton<TService, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddSingleton(typeof(TService), implementationFactory);
        }

        /// <summary>
        /// 添加一个类型为 <paramref name="serviceType"/> 的单例服务到指定 <see cref="IServiceCollection"/> 中。
        /// 并由 <paramref name="implementationInstance"/> 指定其实现实例。
        /// 
        /// </summary>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="serviceType">将注册的服务类型。</param>
        /// <param name="implementationInstance">服务的实例。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton(
            this IServiceCollection services,
            Type serviceType,
            object implementationInstance)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationInstance == null)
            {
                throw new ArgumentNullException(nameof(implementationInstance));
            }

            var serviceDescriptor = new ServiceDescriptor(serviceType, implementationInstance);
            services.Add(serviceDescriptor);
            return services;
        }

        /// <summary>
        /// 添加一个类型为 <typeparamref name="TService"/> 的单例服务到指定 <see cref="IServiceCollection"/> 中，
        /// 并由 <paramref name="implementationInstance"/> 指定其实现实例。
        /// 
        /// </summary>
        /// <typeparam name="TService">将添加的服务类型。</typeparam>
        /// <param name="services">用来添加服务的 <see cref="IServiceCollection"/>。</param>
        /// <param name="implementationInstance">服务的实例。</param>
        /// <returns>操作完成后当前实例的引用。</returns>
        /// <seealso cref="ServiceLifetime.Singleton"/>
        public static IServiceCollection AddSingleton<TService>(
            this IServiceCollection services,
            TService implementationInstance)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (implementationInstance == null)
            {
                throw new ArgumentNullException(nameof(implementationInstance));
            }

            return services.AddSingleton(typeof(TService), implementationInstance);
        }

        private static IServiceCollection Add(
            IServiceCollection collection,
            Type serviceType,
            Type implementationType,
            ServiceLifetime lifetime)
        {
            var descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime);
            collection.Add(descriptor);
            return collection;
        }

        private static IServiceCollection Add(
            IServiceCollection collection,
            Type serviceType,
            Func<IServiceProvider, object> implementationFactory,
            ServiceLifetime lifetime)
        {
            var descriptor = new ServiceDescriptor(serviceType, implementationFactory, lifetime);
            collection.Add(descriptor);
            return collection;
        }
    }
}
