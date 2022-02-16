using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillMachine : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p)
            p.canRefill = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p)
            p.canRefill = false;
    }
}
