// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// ��ӷ��� <see cref="IServiceCollection" /> ����չ������
    /// </summary>
    public static class ServiceCollectionServiceExtensions
    {
        /// <summary>
        /// ���һ������Ϊ <paramref name="serviceType"/> ��˲ʱ����ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <paramref name="implementationType"/> ָ����ʵ�����͡�
        /// 
        /// </summary>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="serviceType">��ע��ķ������͡�</param>
        /// <param name="implementationType">�����ʵ�����͡�</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <paramref name="serviceType"/> ��˲ʱ����ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <paramref name="implementationFactory"/> ָ����ʵ�ֵĹ�����
        /// 
        /// </summary>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="serviceType">��ע��ķ������͡�</param>
        /// <param name="implementationFactory">��������Ĺ�����</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <typeparamref name="TService"/> ��˲ʱ����ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <typeparamref name="TImplementation"/> ָ����ʵ�����͡�
        /// 
        /// </summary>
        /// <typeparam name="TService">����ӵķ������͡�</typeparam>
        /// <typeparam name="TImplementation">����ʵ�ַ�������͡�</typeparam>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <paramref name="serviceType"/> ��˲ʱ����
        /// ָ�� <see cref="IServiceCollection"/> �С�
        /// </summary>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="serviceType">����ע���ʵ�ַ�������͡�</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <typeparamref name="TService"/> ��˲ʱ����
        /// ָ�� <see cref="IServiceCollection"/> �С�
        /// </summary>
        /// <typeparam name="TService">��Ҫ��ӵķ������͡�</typeparam>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <typeparamref name="TService"/> ��˲ʱ����ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <paramref name="implementationFactory"/> ָ����ʵ�ֵĹ�����
        /// 
        /// </summary>
        /// <typeparam name="TService">����ӵķ������͡�</typeparam>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="implementationFactory">��������Ĺ�����</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <typeparamref name="TService"/> ��˲ʱ����ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <typeparamref name="TImplementation" /> ָ����ʵ�����ͣ�
        /// �� <paramref name="implementationFactory"/> ָ����ʵ�ֵĹ�����
        /// 
        /// </summary>
        /// <typeparam name="TService">����ӵķ������͡�</typeparam>
        /// <typeparam name="TImplementation">����ʵ�ַ�������͡�</typeparam>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="implementationFactory">��������Ĺ�����</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <paramref name="serviceType"/> �����������ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <paramref name="implementationType"/> ָ����ʵ�����͡�
        /// 
        /// </summary>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="serviceType">��ע��ķ������͡�</param>
        /// <param name="implementationType">�����ʵ�����͡�</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <paramref name="serviceType"/> �����������ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <paramref name="implementationFactory"/> ָ����ʵ�ֵĹ�����
        /// 
        /// </summary>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="serviceType">��ע��ķ������͡�</param>
        /// <param name="implementationFactory">��������Ĺ�����</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <typeparamref name="TService"/> �����������ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <typeparamref name="TImplementation"/> ָ����ʵ�����͡�
        /// 
        /// </summary>
        /// <typeparam name="TService">����ӵķ������͡�</typeparam>
        /// <typeparam name="TImplementation">����ʵ�ַ�������͡�</typeparam>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <paramref name="serviceType"/> �����������
        /// ָ�� <see cref="IServiceCollection"/> �С�
        /// </summary>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="serviceType">����ע���ʵ�ַ�������͡�</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <typeparamref name="TService"/> �����������
        /// ָ�� <see cref="IServiceCollection"/> �С�
        /// </summary>
        /// <typeparam name="TService">��Ҫ��ӵķ������͡�</typeparam>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <typeparamref name="TService"/> �����������ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <paramref name="implementationFactory"/> ָ����ʵ�ֵĹ�����
        /// 
        /// </summary>
        /// <typeparam name="TService">����ӵķ������͡�</typeparam>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="implementationFactory">��������Ĺ�����</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <typeparamref name="TService"/> �����������ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <typeparamref name="TImplementation" /> ָ����ʵ�����ͣ�
        /// �� <paramref name="implementationFactory"/> ָ����ʵ�ֵĹ�����
        /// 
        /// </summary>
        /// <typeparam name="TService">����ӵķ������͡�</typeparam>
        /// <typeparam name="TImplementation">����ʵ�ַ�������͡�</typeparam>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="implementationFactory">��������Ĺ�����</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <paramref name="serviceType"/> �ĵ�������ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <paramref name="implementationType"/> ָ����ʵ�����͡�
        /// 
        /// </summary>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="serviceType">��ע��ķ������͡�</param>
        /// <param name="implementationType">�����ʵ�����͡�</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <paramref name="serviceType"/> �ĵ�������ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <paramref name="implementationFactory"/> ָ����ʵ�ֵĹ�����
        /// 
        /// </summary>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="serviceType">��ע��ķ������͡�</param>
        /// <param name="implementationFactory">��������Ĺ�����</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <typeparamref name="TService"/> �ĵ�������ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <typeparamref name="TImplementation"/> ָ����ʵ�����͡�
        /// 
        /// </summary>
        /// <typeparam name="TService">����ӵķ������͡�</typeparam>
        /// <typeparam name="TImplementation">����ʵ�ַ�������͡�</typeparam>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <paramref name="serviceType"/> �ĵ�������
        /// ָ�� <see cref="IServiceCollection"/> �С�
        /// </summary>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="serviceType">����ע���ʵ�ַ�������͡�</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <typeparamref name="TService"/> �ĵ�������
        /// ָ�� <see cref="IServiceCollection"/> �С�
        /// </summary>
        /// <typeparam name="TService">��Ҫ��ӵķ������͡�</typeparam>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <typeparamref name="TService"/> �ĵ�������ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <paramref name="implementationFactory"/> ָ����ʵ�ֵĹ�����
        /// 
        /// </summary>
        /// <typeparam name="TService">����ӵķ������͡�</typeparam>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="implementationFactory">��������Ĺ�����</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <typeparamref name="TService"/> �ĵ�������ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <typeparamref name="TImplementation" /> ָ����ʵ�����ͣ�
        /// �� <paramref name="implementationFactory"/> ָ����ʵ�ֵĹ�����
        /// 
        /// </summary>
        /// <typeparam name="TService">����ӵķ������͡�</typeparam>
        /// <typeparam name="TImplementation">����ʵ�ַ�������͡�</typeparam>
        /// <param name="services">����ʵ�ַ�������͡�</param>
        /// <param name="implementationFactory">��������Ĺ�����</param>
        /// <returns>��������Ĺ�����</returns>
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
        /// ���һ������Ϊ <paramref name="serviceType"/> �ĵ�������ָ�� <see cref="IServiceCollection"/> �С�
        /// ���� <paramref name="implementationInstance"/> ָ����ʵ��ʵ����
        /// 
        /// </summary>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="serviceType">��ע��ķ������͡�</param>
        /// <param name="implementationInstance">�����ʵ����</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
        /// ���һ������Ϊ <typeparamref name="TService"/> �ĵ�������ָ�� <see cref="IServiceCollection"/> �У�
        /// ���� <paramref name="implementationInstance"/> ָ����ʵ��ʵ����
        /// 
        /// </summary>
        /// <typeparam name="TService">����ӵķ������͡�</typeparam>
        /// <param name="services">������ӷ���� <see cref="IServiceCollection"/>��</param>
        /// <param name="implementationInstance">�����ʵ����</param>
        /// <returns>������ɺ�ǰʵ�������á�</returns>
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
