using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBotCore.Interfaces;

namespace UBotCore.BaseClasses;

public abstract class NodeBase: INode
{
    public Guid Id { get; set; }
    public INode Children { get; set; }

    public abstract string ToScript();

    public abstract void Execute();
}
