using System;
namespace PROJET
{
    public class Lines
    {
        private Node from;
        private Node to;
        private int id;

        public int GetId()
        {
            return this.id;
        }

        public Node GetFrom()
        {
            return this.from;
        }

        public string GetIdOfFromNode()
        {
            return this.from.GetNodeId();
        }

        public Node GetTo()
        {
            return this.to;
        }
        public string GetIdOfToNode()
        {
            return this.to.GetNodeId();
        }
        public Lines(Node f, Node t, int id)
        {
            this.from = f;
            this.to = t;
            this.id = id;
        }
        
    }
}
