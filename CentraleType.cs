using System;
namespace PROJET
{
    public abstract class CentraleType : Node
    {
        public CentraleType(string id) : base(id)
        {
            this.id = id;
        }
    }
}
