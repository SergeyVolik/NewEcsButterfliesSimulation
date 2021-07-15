using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class ButterfliesMoveSystem : SystemBase
{

    protected override void OnUpdate()
    {

        var settigns = GetSingleton<ButterfliesSimulationSettings>();


        Entities.ForEach((ref Translation translation, in LifeTime lifeTime) =>
        {


        
            var frequency = math.sin(lifeTime.Value * settigns.WingsFrequency);

            translation.Value += new float3(0, math.remap(-1, 1, -0.005f, 0.005f, frequency), 0);


        }).Schedule();

        




    }
}
