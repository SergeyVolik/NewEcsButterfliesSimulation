using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.InputSystem;

public class CreateButterfliesSystem : SystemBase
{

    protected override void OnUpdate()
    {

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
           EntityManager.Instantiate(PrefabsConvertion.BatterfyPrefabEntity);
        }
      

    }
}
