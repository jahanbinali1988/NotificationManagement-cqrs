using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Domain.Utilities
{
    //public class StateFactory<T> where T : class
    //{
    //    private readonly List<T> _states = new List<T>();
    //    public StateFactory()
    //    {
    //        var states = Assembly.GetAssembly(typeof(T)).GetTypes()
    //            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))).ToList();
    //        states.ForEach(state => _states.Add((T)Activator.CreateInstance(state)));
    //    }
    //    public T Create(long state)
    //    {
    //        return _states.First(a => a.GetType()
    //            .GetCustomAttributes(typeof(StateValue), true)
    //            .OfType<StateValue>().First().Value == state);
    //    }

    //    public long Create(T state)
    //    {
    //        return state.GetType().GetCustomAttributes<StateValue>().First().Value;
    //    }
    //}
}
