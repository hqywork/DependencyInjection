// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection.Abstractions;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// �� <see cref="IServiceProvider" /> ��ȡ�������չ������
    /// </summary>
    public static class ServiceProviderServiceExtensions
    {
        /// <summary>
        /// �� <see cref="IServiceProvider"/> ��ȡ <typeparamref name="T"/> ���͵ķ���
        /// </summary>
        /// <typeparam name="T">Ҫ��ȡ�����������͡�</typeparam>
        /// <param name="provider">����ȡ�ط������� <see cref="IServiceProvider"/>��</param>
        /// <returns>����Ϊ <typeparamref name="T"/> �ķ�����������ã�<c>null</c>����û���ҵ�����ʱ����</returns>
        public static T GetService<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return (T)provider.GetService(typeof(T));
        }

        /// <summary>
        /// �� <see cref="IServiceProvider"/> ��ȡ <paramref name="serviceType"/> ���͵ķ���
        /// </summary>
        /// <param name="provider">����ȡ�ط������� <see cref="IServiceProvider"/>��</param>
        /// <param name="serviceType">Ҫ��ȡ�����������͡�</param>
        /// <returns>����Ϊ <paramref name="serviceType"/> �ķ������</returns>
        /// <exception cref="System.InvalidOperationException">���Ҳ��� <paramref name="serviceType"/> ���͵ķ���ʱ������</exception>
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
        /// �� <see cref="IServiceProvider"/> ��ȡ <typeparamref name="T"/> ���͵ķ���
        /// </summary>
        /// <typeparam name="T">Ҫ��ȡ�����������͡�</typeparam>
        /// <param name="provider">����ȡ�ط������� <see cref="IServiceProvider"/>��</param>
        /// <returns>����Ϊ <typeparamref name="T"/> �ķ������</returns>
        /// <exception cref="System.InvalidOperationException">���Ҳ��� <typeparamref name="T"/> ���͵ķ���ʱ������</exception>
        public static T GetRequiredService<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return (T)provider.GetRequiredService(typeof(T));
        }

        /// <summary>
        /// �� <see cref="IServiceProvider"/> ��ȡ <typeparamref name="T"/> ���͵ķ��񹹳ɵĿ�ö������
        /// </summary>
        /// <typeparam name="T">Ҫ��ȡ�����������͡�</typeparam>
        /// <param name="provider">����ȡ�ط������� <see cref="IServiceProvider"/>��</param>
        /// <returns>����Ϊ <typeparamref name="T"/> �ķ��񹹳ɵ�ö������</returns>
        public static IEnumerable<T> GetServices<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return provider.GetRequiredService<IEnumerable<T>>();
        }

        /// <summary>
        /// �� <see cref="IServiceProvider"/> ��ȡ <paramref name="serviceType"/> ���͵ķ��񹹳ɵĿ�ö������
        /// </summary>
        /// <param name="provider">����ȡ�ط������� <see cref="IServiceProvider"/>��</param>
        /// <param name="serviceType">Ҫ��ȡ�����������͡�</param>
        /// <returns>����Ϊ <paramref name="serviceType"/> �ķ��񹹳ɵ�ö������</returns>
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
        /// ����һ�� <see cref="IServiceScope"/>������������������Χ����
        /// </summary>
        /// <param name="provider">���д�����Χ�� <see cref="IServiceProvider"/>��</param>
        /// <returns>���Ա�����������Χ����� <see cref="IServiceScope"/>��</returns>
        public static IServiceScope CreateScope(this IServiceProvider provider)
        {
            return provider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        }
    }
}
