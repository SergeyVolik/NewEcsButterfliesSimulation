using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup))]
public class IndividualRandomDataSystem : SystemBase
{

    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, int entityInQueryIndex, ref IndividualRandomData randomData) =>
        {
            randomData.Value = Unity.Mathematics.Random.CreateFromIndex((uint)entityInQueryIndex);

        }).ScheduleParallel();
    }
}