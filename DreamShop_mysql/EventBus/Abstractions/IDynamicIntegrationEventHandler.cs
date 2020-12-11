using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Abstractions
{
    /// <summary>
    /// 接口 
    /// </summary>
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic evenData);

    }
}
