namespace Singelton.Models
{
    using Singelton.Contracts;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SingeltonDataContainer : ISingeltonContainer
    {
        private static SingeltonDataContainer instance
          = null;

        private static readonly object locker = new object();

        private Dictionary<string, int> capitals = new Dictionary<string, int>();

        private SingeltonDataContainer()
        {
            Console.WriteLine("Initializing singelton object");

            foreach (var line in File.ReadAllLines("./../../../capitals.txt"))
            {
                var item = line.Split();

                for (int i = 0; i < item.Length; i += 2)
                {
                    capitals.Add(item[i], int.Parse(item[i + 1]));
                }

            }
        }

        public static SingeltonDataContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new SingeltonDataContainer();
                        }
                    }
                }

                return instance;
            }
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
