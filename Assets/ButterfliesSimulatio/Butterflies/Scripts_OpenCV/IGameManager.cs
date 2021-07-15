using UnityEngine;
using System.Drawing;
using System.Collections.Generic;

namespace Global
{
    public interface IGameManager
    {
        void SpawnCreature(Texture2D tex, int id, string name);
        List<GameObject> GetSpawnedCreatures();
        Vector3 GetNavmeshPosition(Vector3 center);
    }
}
