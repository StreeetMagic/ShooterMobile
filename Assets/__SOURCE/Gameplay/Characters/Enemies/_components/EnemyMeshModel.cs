using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMeshModel : MonoBehaviour
  {
    public EnemyTypeId EnemyId;

    public List<SkinnedMeshRenderer> Meshes;
  }
}