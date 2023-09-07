using System;
using System.Reflection;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Practice.Scripts.Common
{
    using System.Collections.Generic;
    public class ClassGetter
    {
        public static Dictionary<string,T> GetChilds<T>(Type parentType)
        {
            Dictionary<string,T> childs = new Dictionary<string,T>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] childTypes = assembly.GetTypes().Where(type => type.IsSubclassOf(parentType)).ToArray();
        
            foreach (Type childType in childTypes)
            {
                T childInstance = (T)Activator.CreateInstance(childType);
                if(childInstance != null)
                    childs.Add(childType.Name,childInstance);
            }
            return childs;
        }

        public static Dictionary<string, U> GetResourcePrefabs<U>(string path) where U : UnityEngine.Object
        {
            Dictionary<string, U> Prefabs = new Dictionary<string, U>();
            U[] objects = Resources.LoadAll<U>(path);
            Array.ForEach(objects,x => Prefabs.Add(x.name,x));
            return Prefabs;
        }
    }
}