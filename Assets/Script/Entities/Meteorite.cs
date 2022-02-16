using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public float time;
    public float speed;
    public SpriteRenderer sprite;

    public void init()
    {

        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public void UpdateMeteorite()
    {

       transform.position += (transform.up * Time.deltaTime) * speed;
    }

    public void Die()
    {
        GameObject.Destroy(gameObject);

    }
}
