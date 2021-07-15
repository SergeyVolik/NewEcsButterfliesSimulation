using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class WingsAnimationSystem : SystemBase
{
    BeginInitializationEntityCommandBufferSystem bufferSystem;
    protected override void OnCreate()
    {
        base.OnCreate();
        bufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }

    protected override void OnStartRunning()
    {
        base.OnStartRunning();

        EntityCommandBuffer.ParallelWriter ecb = bufferSystem.CreateCommandBuffer().AsParallelWriter();

        Entities.WithAll<Butterfly>().ForEach((Entity entity, int entityInQueryIndex, IndividualRandomData rnd) =>
        {
            ecb.AddComponent(entityInQueryIndex, entity, new ButterflyInitData()
            {
                PhaseOffset = rnd.Value.NextFloat(-2, 2)
            });
        }).Schedule();

        bufferSystem.AddJobHandleForProducer(this.Dependency);
    }

    protected override void OnUpdate()
    {

        var settigns = GetSingleton<ButterfliesSimulationSettings>();
        var deltaTime = Time.DeltaTime;


        //Entities.ForEach((ref Translation translation, in Butterfly wing, in LifeTime lifeTime) =>
        //{


        //    var leftWing = GetComponent<ButterflyWing>(wing.LeftWing);
        //    var rightWing = GetComponent<ButterflyWing>(wing.RightWing);

        //    var leftWingRotation = GetComponent<Rotation>(wing.LeftWing);
        //    var rightWingRotation = GetComponent<Rotation>(wing.RightWing);

        //    var frequency = math.sin(lifeTime.Value * settigns.WingsFrequency);


        //    var remap = math.remap(-1, 1, -0.5f * settigns.WingsFrequency, 0.5f * settigns.WingsFrequency, frequency);



        //    SetComponent(wing.LeftWing, new Rotation { Value = math.mul(leftWingRotation.Value, quaternion.RotateZ(math.radians(remap))) });
        //    SetComponent(wing.RightWing, new Rotation { Value = math.mul(rightWingRotation.Value, quaternion.RotateZ(math.radians(remap))) });


        //}).WithoutBurst().Schedule();

    }
}
