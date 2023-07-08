using System.Collections;
using UnityEngine;

public class StrikeAttacker : MonoBehaviour
{
    

    public void OnAttack(bool on,GameObject other)
    {
        if (enabled)
        {
            print($"OnAttack");
        
            StartCoroutine(DamageCoroutine());
        }
    }

    private IEnumerator DamageCoroutine()
    {
        yield return null;
    }
}
