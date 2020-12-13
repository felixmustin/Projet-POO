using System;
using System.Collections.Generic;

namespace PROJET
{
    public class Node
    {
        public string id;
        private List<Lines> distribution = new List<Lines>();
        private List<Lines> reception = new List<Lines>();
        public double Production;

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
            else if (this is ConcentrationNode)
            {
                if (this.GetDistribution().Count>0){
                        throw new Exception("Un noeud de concentration n'a qu'une ligne en sortie");
                    }
                else{
                    this.distribution.Add(e);
                    e.GetTo().reception.Add(e);
                }
            }
            else if (e.GetTo() is DistributionNode)
            {  
                if (e.GetTo().GetReception().Count>0){
                    throw new Exception("Un noeud de distribution n'a qu'une ligne en entrée");
                }
                else{
                    this.distribution.Add(e);
                    e.GetTo().reception.Add(e);
                }
            }
            else 
            {
                this.distribution.Add(e);
                e.GetTo().reception.Add(e);
            }
        }

        public List<Lines> GetDistribution()
        {
            return this.distribution;
        }
        public List<Lines> GetReception()
        {
            return this.reception;
        }

        public Node(string id)
        {
            this.id = id;
        }
    }
}