using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMeshModel : MonoBehaviour
  {
    public EnemyTypeId EnemyId;

    public List<SkinnedMeshRenderer> Meshes;
  }
}