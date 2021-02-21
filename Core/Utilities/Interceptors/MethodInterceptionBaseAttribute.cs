using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;//Atofac 

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }//oncelik

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
