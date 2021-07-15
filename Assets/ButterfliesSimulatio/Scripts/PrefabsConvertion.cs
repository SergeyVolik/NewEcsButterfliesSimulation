using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Entities.Hybrid.Internal;

public class PrefabsConvertion : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{

    [SerializeField]
    private GameObject BatterfyPrefab;

    public static Entity BatterfyPrefabEntity;


    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        BatterfyPrefabEntity = conversionSystem.GetPrimaryEntity(BatterfyPrefab);
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        //referencedPrefabs.Add(BatterfyPrefab);
        GeneratedAuthoringComponentImplementation
            .AddReferencedPrefab(referencedPrefabs, BatterfyPrefab);
    }
}
