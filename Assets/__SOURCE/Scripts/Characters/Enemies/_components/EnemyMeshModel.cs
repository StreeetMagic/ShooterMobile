using System.Collections.Generic;
using UnityEngine;

namespace Characters.Enemies._components
{
  public class EnemyMeshModel : MonoBehaviour
  {
    public EnemyTypeId EnemyId;

    public List<SkinnedMeshRenderer> Meshes;
  }
}