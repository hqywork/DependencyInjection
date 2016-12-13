// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 用于构造服务容器（<see cref="IServiceProvider"/>） 的 <see cref="IServiceCollection"/> 扩展方法。
    /// </summary>
    public static class ServiceCollectionContainerBuilderExtensions
    {
        /// <summary>
        /// 从 <see cref="IServiceCollection"/> 创建一个 <see cref="IServiceProvider"/> 容器服务。
        /// 
        /// </summary>
        /// <param name="services">包含服务描述的 <see cref="IServiceCollection"/>。</param>
        /// <returns><see cref="IServiceProvider"/> 服务容器。</returns>

        public static IServiceProvider BuildServiceProvider(this IServiceCollection services)
        {
            return BuildServiceProvider(services, validateScopes: false);
        }

        /// <summary>
        /// 从 <see cref="IServiceCollection"/> 创建一个 <see cref="IServiceProvider"/> 容器服务。
        /// 可选择是否启用作用域验证。
        /// </summary>
        /// <param name="services">包含服务描述的 <see cref="IServiceCollection"/>。</param>
        /// <param name="validateScopes">
        /// 如果作用域服务不能从根提供者解析则返回真（<c>true</c>）；否则返回假（<c>false</c>）.
        /// </param>
        /// <returns><see cref="IServiceProvider"/> 服务容器。</returns>
        public static IServiceProvider BuildServiceProvider(this IServiceCollection services, bool validateScopes)
        {
            return new ServiceProvider(services, validateScopes);
        }
    }
}
