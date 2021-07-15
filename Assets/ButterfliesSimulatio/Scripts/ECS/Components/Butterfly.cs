using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[Serializable, GenerateAuthoringComponent]
public struct Butterfly : IComponentData
{
    public Entity LeftWing;
    public Entity RightWing;
}
