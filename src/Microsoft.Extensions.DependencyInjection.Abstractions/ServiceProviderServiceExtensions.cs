// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection.Abstractions;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 从 <see cref="IServiceProvider" /> 获取服务的扩展方法。
    /// </summary>
    public static class ServiceProviderServiceExtensions
    {
        /// <summary>
        /// 从 <see cref="IServiceProvider"/> 获取 <typeparamref name="T"/> 类型的服务。
        /// </summary>
        /// <typeparam name="T">要获取服务对象的类型。</typeparam>
        /// <param name="provider">从中取回服务对象的 <see cref="IServiceProvider"/>。</param>
        /// <returns>类型为 <typeparamref name="T"/> 的服务对象或空引用（<c>null</c>，当没有找到服务时）。</returns>
        public static T GetService<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return (T)provider.GetService(typeof(T));
        }

        /// <summary>
        /// 从 <see cref="IServiceProvider"/> 获取 <paramref name="serviceType"/> 类型的服务。
        /// </summary>
        /// <param name="provider">从中取回服务对象的 <see cref="IServiceProvider"/>。</param>
        /// <param name="serviceType">要获取服务对象的类型。</param>
        /// <returns>类型为 <paramref name="serviceType"/> 的服务对象。</returns>
        /// <exception cref="System.InvalidOperationException">当找不到 <paramref name="serviceType"/> 类型的服务时引发。</exception>
        public static object GetRequiredService(this IServiceProvider provider, Type serviceType)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            var requiredServiceSupportingProvider = provider as ISupportRequiredService;
            if (requiredServiceSupportingProvider != null)
            {
                return requiredServiceSupportingProvider.GetRequiredService(serviceType);
            }

            var service = provider.GetService(serviceType);
            if (service == null)
            {
                throw new InvalidOperationException(Resources.FormatNoServiceRegistered(serviceType));
            }

            return service;
        }

        /// <summary>
        /// 从 <see cref="IServiceProvider"/> 获取 <typeparamref name="T"/> 类型的服务。
        /// </summary>
        /// <typeparam name="T">要获取服务对象的类型。</typeparam>
        /// <param name="provider">从中取回服务对象的 <see cref="IServiceProvider"/>。</param>
        /// <returns>类型为 <typeparamref name="T"/> 的服务对象。</returns>
        /// <exception cref="System.InvalidOperationException">当找不到 <typeparamref name="T"/> 类型的服务时引发。</exception>
        public static T GetRequiredService<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return (T)provider.GetRequiredService(typeof(T));
        }

        /// <summary>
        /// 从 <see cref="IServiceProvider"/> 获取 <typeparamref name="T"/> 类型的服务构成的可枚举数。
        /// </summary>
        /// <typeparam name="T">要获取服务对象的类型。</typeparam>
        /// <param name="provider">从中取回服务对象的 <see cref="IServiceProvider"/>。</param>
        /// <returns>类型为 <typeparamref name="T"/> 的服务构成的枚举数。</returns>
        public static IEnumerable<T> GetServices<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return provider.GetRequiredService<IEnumerable<T>>();
        }

        /// <summary>
        /// 从 <see cref="IServiceProvider"/> 获取 <paramref name="serviceType"/> 类型的服务构成的可枚举数。
        /// </summary>
        /// <param name="provider">从中取回服务对象的 <see cref="IServiceProvider"/>。</param>
        /// <param name="serviceType">要获取服务对象的类型。</param>
        /// <returns>类型为 <paramref name="serviceType"/> 的服务构成的枚举数。</returns>
        public static IEnumerable<object> GetServices(this IServiceProvider provider, Type serviceType)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            var genericEnumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)provider.GetRequiredService(genericEnumerable);
        }

        /// <summary>
        /// 创建一个 <see cref="IServiceScope"/>，它可以用来解析范围服务。
        /// </summary>
        /// <param name="provider">从中创建范围的 <see cref="IServiceProvider"/>。</param>
        /// <returns>可以被用来解析范围服务的 <see cref="IServiceScope"/>。</returns>
        public static IServiceScope CreateScope(this IServiceProvider provider)
        {
            return provider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        }
    }
}
