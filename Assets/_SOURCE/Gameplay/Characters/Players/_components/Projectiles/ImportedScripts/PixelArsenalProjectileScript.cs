using UnityEngine;

namespace Gameplay.Characters.Players.Projectiles.ImportedScripts
{
  public class PixelArsenalProjectileScript : MonoBehaviour
  {
    public float ScaleImpact = 0.2f;
    public float ScaleBullet = 0.2f;
    public float ScaleMuzzle = 0.2f;

    [Tooltip("Effect spawned when projectile hits a collider")]
    public GameObject impactParticle;

    [Tooltip("Effect attached to the gameobject as child")]
    public GameObject projectileParticle;

    [Tooltip("Effect attached to the gameobject as child")]
    public GameObject muzzleParticle;

    [Header("Adjust if not using Sphere Collider")]
    public float colliderRadius = 1f;

    [Range(0f, 1f)] [Tooltip("This is an offset that moves the impact effect slightly away from the point of impact to reduce clipping of the impact effect")]
    public float collideOffset = 0.15f;

    private void Start()
    {
      impactParticle.transform.localScale = new Vector3(ScaleImpact, ScaleImpact, ScaleImpact);
      projectileParticle.transform.localScale = new Vector3(ScaleBullet, ScaleBullet, ScaleBullet);
      muzzleParticle.transform.localScale = new Vector3(ScaleMuzzle, ScaleMuzzle, ScaleMuzzle);

      projectileParticle = Instantiate(projectileParticle, transform.position, transform.rotation);
      projectileParticle.transform.parent = transform;

      if (muzzleParticle)
      {
        muzzleParticle = Instantiate(muzzleParticle, transform.position, transform.rotation);
        Destroy(muzzleParticle, 1.5f);
      }

      // Игнорируем коллизии с объектами на слое "Player"
      Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Player"));
    }

    private void FixedUpdate()
    {
      if (GetComponent<Rigidbody>().velocity.magnitude != 0)
        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);

      float radius =
        transform
          .GetComponent<SphereCollider>()
          ? transform.GetComponent<SphereCollider>().radius
          : colliderRadius;

      Vector3 direction =
        transform
          .GetComponent<Rigidbody>()
          .velocity;

      if (transform.GetComponent<Rigidbody>().useGravity)
        direction += Physics.gravity * Time.deltaTime;

      direction = direction.normalized;

      float detectionDistance =
        transform
          .GetComponent<Rigidbody>()
          .velocity
          .magnitude * Time.deltaTime;

      if (Physics.SphereCast(transform.position, radius, direction, out RaycastHit hit, detectionDistance))
      {
        transform.position = hit.point + hit.normal * collideOffset;

        GameObject impactP = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, hit.normal));

        ParticleSystem[] trails = GetComponentsInChildren<ParticleSystem>();

        for (int i = 1; i < trails.Length; i++)
        {
          ParticleSystem trail = trails[i];

          if (trail.gameObject.name.Contains("Trail"))
          {
            trail.transform.SetParent(null);
            Destroy(trail.gameObject, 2f);
          }
        }

        Destroy(projectileParticle, 3f);
        Destroy(impactP, 3.5f);
        Destroy(gameObject);
      }
    }
  }
}