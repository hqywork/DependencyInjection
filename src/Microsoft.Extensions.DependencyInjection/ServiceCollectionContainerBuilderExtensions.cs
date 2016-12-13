// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// ���ڹ������������<see cref="IServiceProvider"/>�� �� <see cref="IServiceCollection"/> ��չ������
    /// </summary>
    public static class ServiceCollectionContainerBuilderExtensions
    {
        /// <summary>
        /// �� <see cref="IServiceCollection"/> ����һ�� <see cref="IServiceProvider"/> ��������
        /// 
        /// </summary>
        /// <param name="services">�������������� <see cref="IServiceCollection"/>��</param>
        /// <returns><see cref="IServiceProvider"/> ����������</returns>

        public static IServiceProvider BuildServiceProvider(this IServiceCollection services)
        {
            return BuildServiceProvider(services, validateScopes: false);
        }

        /// <summary>
        /// �� <see cref="IServiceCollection"/> ����һ�� <see cref="IServiceProvider"/> ��������
        /// ��ѡ���Ƿ�������������֤��
        /// </summary>
        /// <param name="services">�������������� <see cref="IServiceCollection"/>��</param>
        /// <param name="validateScopes">
        /// �������������ܴӸ��ṩ�߽����򷵻��棨<c>true</c>�������򷵻ؼ٣�<c>false</c>��.
        /// </param>
        /// <returns><see cref="IServiceProvider"/> ����������</returns>
        public static IServiceProvider BuildServiceProvider(this IServiceCollection services, bool validateScopes)
        {
            return new ServiceProvider(services, validateScopes);
        }
    }
}
