using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class ShootAttackAuthoring : MonoBehaviour {
  public float timerMax;
  public int damageAmount;
  public int bulletSpeed;
  public float attackDistance;
  public Transform bulletSpawnPositionTransform;


  public class Baker : Baker<ShootAttackAuthoring> {
    public override void Bake(ShootAttackAuthoring authoring) {
      Entity entity = GetEntity(TransformUsageFlags.Dynamic);
      AddComponent(entity, new ShootAttack {
        timerMax = authoring.timerMax,
        damageAmount = authoring.damageAmount,
        speed = authoring.bulletSpeed,
        attackDistance = authoring.attackDistance,
        bulletSpawnLocalPosition = authoring.bulletSpawnPositionTransform.localPosition,
      });
    }
  }
}

public struct ShootAttack : IComponentData {
  public float timer;
  public float timerMax;
  public int damageAmount;
  public int speed;
  public float attackDistance;
  public float3 bulletSpawnLocalPosition;
}
