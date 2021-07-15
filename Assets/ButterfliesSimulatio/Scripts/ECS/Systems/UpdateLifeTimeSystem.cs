using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class UpdateLifeTimeSystem : SystemBase
{

    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;


        Entities.ForEach((ref LifeTime lifeTime) =>
        {

            lifeTime.Value += deltaTime;

        }).Schedule();




    }
}
