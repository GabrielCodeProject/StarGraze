using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteManager
{
    const float left = -60f;
    const float right = 60f;
    const float haut = 60f;
    const float bas = -60f;
    const float meteoriteTime = 5f;

    float timeCreateMeteor;

    float speed = 20;

    private static MeteoriteManager instance = null;

    private MeteoriteManager()
    {
    }

    public static MeteoriteManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MeteoriteManager();
            }
            return instance;
        }
    }

    List<Meteorite> meteoritesGo;


    public void init()
    {
        meteoritesGo = new List<Meteorite>();
        timeCreateMeteor = Random.Range(0.2f, 0.8f) + Time.time;
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            CreateRandomMetheorite();
        }

        foreach (Meteorite me in meteoritesGo)
        {
            me.UpdateMeteorite();
        }

        for(int i = meteoritesGo.Count -1 ; i >= 0; i--)
        {
            if (meteoritesGo[i].time < Time.time)
            {
                meteoritesGo[i].Die();
                meteoritesGo.RemoveAt(i);
            }

             
        }

        if (Time.time > timeCreateMeteor) {
            timeCreateMeteor = Random.Range(0.2f, 0.8f) + Time.time;
            CreateRandomMetheorite();
        }




        


    }

    public void FixedUpdate()
    {

    }

    public void CreateRandomMetheorite()
    {
        GameObject metheorite = GameObject.Instantiate(Resources.Load("Prefabs/Metheorite")) as GameObject;
        Meteorite me = metheorite.GetComponent<Meteorite>();
        me.init();

        me.speed = Random.Range(20, 41);

        int dessous = Random.Range(0, 2);

       

        if (dessous == 1) {
            me.sprite.sortingOrder = -1;
        }
        else
        {
            me.sprite.sortingOrder = 200;
        }

        int randomPosition = Random.Range(0, 2);
        float hauteur = (Random.Range(bas, haut));

        //Calcul pourcent
        float pourcent = System.Math.Abs(hauteur) / haut;
        //calcul angle
        float angle = 40 * pourcent;
        angle = angle + Random.Range(-20, 21);
        if (randomPosition == 0)
        {
            //gauche
            metheorite.transform.eulerAngles = new Vector3(0, 0, -90);

            metheorite.transform.position = new Vector3(left, hauteur);

       
            float endAngle;
            if (hauteur < 0)
            {
                endAngle = -90 + angle;

            }
            else {
                 endAngle = -90 - angle;
            }


            metheorite.transform.eulerAngles = new Vector3(0, 0, endAngle);

        }
        else
        {
            //droite
            metheorite.transform.eulerAngles = new Vector3(0, 0, 90);

         
            metheorite.transform.position = new Vector3(right,hauteur);


            float endAngle;
            if (hauteur < 0)
            {
                endAngle = 90 - angle;

            }
            else
            {
                endAngle = 90 + angle;
            }

            metheorite.transform.eulerAngles = new Vector3(0, 0, endAngle);



        }

        me.time = Time.time + meteoriteTime;
        meteoritesGo.Add(me);
    }

}
