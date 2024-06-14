using System;
using System.Collections.Generic;

namespace MemoryGame.Utilities
{
    public static class ExtensionMethods
    {
        private static Random _random = new();

        public static List<T> Shuffle<T>(this List<T> original) //original is the capacity of the list
        {
            List<T> shallowInputClone = new List<T>(original);
            List<T> result = new List<T>(shallowInputClone.Count);
            while (shallowInputClone.Count > 0)
            {
                int index = _random.Next(0, shallowInputClone.Count);
                result.Add(shallowInputClone[index]);
                shallowInputClone.RemoveAt(index);
            }
            return result;
        }
    }
}
