// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 指定一个服务描述集合的契约。
    /// </summary>
    public interface IServiceCollection : IList<ServiceDescriptor>
    {
    }
}
