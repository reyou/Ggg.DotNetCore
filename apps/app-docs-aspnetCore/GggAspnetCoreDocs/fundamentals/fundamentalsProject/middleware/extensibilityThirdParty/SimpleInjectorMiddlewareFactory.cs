﻿using System;

using Microsoft.AspNetCore.Http;
using SimpleInjector;

namespace fundamentalsProject.middleware.extensibilityThirdParty
{
    /// <summary>
    /// https://simpleinjector.readthedocs.io/en/latest/quickstart.html
    /// </summary>
    public class SimpleInjectorMiddlewareFactory : IMiddlewareFactory
    {
        private readonly Container _container;

        public SimpleInjectorMiddlewareFactory(Container container)
        {
            _container = container;
        }

        public IMiddleware Create(Type middlewareType)
        {
            return _container.GetInstance(middlewareType) as IMiddleware;
        }

        public void Release(IMiddleware middleware)
        {
            // The container is responsible for releasing resources.
        }
    }
}
