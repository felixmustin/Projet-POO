using System;
using System.Collections.Generic;

namespace PROJET
{
    public class Node
    {
        public string id;
        private List<Lines> distribution = new List<Lines>();


        public string GetNodeId()
        {
            return this.id;
        }

        public void AddDistribution(Lines e)
        {
            if (this.distribution.Contains(e))
            {
                Console.WriteLine("Alredy used");
            }
            else
            {
                this.distribution.Add(e);
            }
        }

        public List<Lines> GetDistribution()
        {
            return this.distribution;
        }

        public Node(string id)
        {
            this.id = id;
        }
    }
}