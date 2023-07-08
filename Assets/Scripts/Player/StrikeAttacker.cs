using System.Collections;
using UnityEngine;

public class StrikeAttacker : MonoBehaviour
{
    [SerializeField] private PlayerEntity player;

    public void OnAttack(bool on,GameObject other)
    {
        if (on && !player.isStun())
        {
            print($"OnAttack");
            EntityBase entity = other.GetComponent<EntityBase>();


            if (entity is PlayerEntity player2)
            {
                Vector3 v1 = player.rb.velocity;
                Vector3 v2 = player2.rb.velocity;

                float m1 = player.getMass();
                float m2 = player2.getMass();

               
                Vector3 v1_ = ((m1 - m2) * v1 + 2 * m2 * v2) / (m1 + m2);

                Vector3 v_ = m1 * v1 + m2 * v2 / (m1 + m2);


                if (v1.magnitude >= 10)
                {
                    player2.GetDamage((v1_ -v1).magnitude * m1 * Managers.Instance.dmgArg * m1 / m2 * player.getMaxSpeed()/ player2.getMaxSpeed(), player);
                    //player.GetDamage(m1 * (v1_ - v1).magnitude * Managers.Instance.dmgArg * 0.0001f*0.3f, player2);
                }

                player.setStun(true);
                player.rb.AddForce(v1_ * 50, ForceMode.Force);;
                StartCoroutine(Stun(m1 / m2));
            }
            else
            {
                entity.GetDamage(player.rb.velocity.magnitude * player.getMass()/150, player);
                StartCoroutine(Stun(0.5f));
            }
        }
    }

    private IEnumerator Stun(float rate = 1f)
    {
        yield return new WaitForSeconds(player.getStunTime()*rate);
        player.setStun(false);
    }
}
