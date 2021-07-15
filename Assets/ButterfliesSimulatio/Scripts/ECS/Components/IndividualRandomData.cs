using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[Serializable, GenerateAuthoringComponent]
public struct IndividualRandomData : IComponentData
{
    public Unity.Mathematics.Random Value;
}
