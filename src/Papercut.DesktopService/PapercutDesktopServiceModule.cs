﻿// Papercut
// 
// Copyright © 2008 - 2012 Ken Robertson
// Copyright © 2013 - 2017 Jaben Cargman
//  
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//  
// http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License. 

namespace Papercut.DesktopService
{
    using System.Reflection;
    using Autofac;
    using Autofac.Core;

    using Papercut.Core.Domain.Application;
    using Papercut.Core.Domain.Settings;
    using Papercut.Core.Infrastructure.Plugins;
    using Papercut.Service.Helpers;
    using Module = Autofac.Module;
    using Papercut.Common.Domain;
    using Papercut.WebUI;
    using Papercut.Core.Domain.Message;

    public class PapercutDesktopServiceModule : Module, IDiscoverableModule
    {
        public IModule Module => this;

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PapercutNativeMessageRepository>()
                .As<IEventHandler<WebUIServerReadyEvent>>()
                .As<IEventHandler<NewMessageEvent>>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}