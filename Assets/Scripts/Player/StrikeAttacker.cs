using System.Collections;
using UnityEngine;

public class StrikeAttacker : MonoBehaviour
{
    [SerializeField] private PlayerEntity player;

    public void OnAttack(bool on,GameObject other)
    {
        if (on)
        {
            print($"OnAttack");

            EntityBase entity = other.GetComponent<EntityBase>();


            if (entity is PlayerEntity player2)
            {
                Vector3 F = player2.rb.velocity - player.rb.velocity;
                player.setStun(true);
                player.rb.AddForce(-F * 100, ForceMode.Force);
                //StartCoroutine(DamageEntity(entity));
                StartCoroutine(Damage(player2));
            }

            StartCoroutine(Stun());

        }
    }

    private IEnumerator Damage(PlayerEntity entity)
    {
        Vector3 v1 = entity.rb.velocity;
        yield return new WaitForSeconds(0.07f);
        v1 = entity.rb.velocity - v1;
        print(v1);
        entity.GetDamage(v1.magnitude/entity.getMass()*Managers.Instance.dmgArg);
    }

    private IEnumerator Stun()
    {
        yield return new WaitForSeconds(0.45f);
        player.setStun(false);
    }
}
