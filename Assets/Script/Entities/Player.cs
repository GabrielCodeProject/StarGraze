using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    private List<Tool> tools;
    private int activeTool;
    private float x, y;
    [SerializeField] private float speed;
    public bool canRefill;
    public bool canAnswer;
    private Rigidbody2D rb;
    private Collider2D collider;
    GameObject cinemachine;


    public GridLayout gl;

    public void InitPlayer()
    {
        //speed = 2;

        cinemachine = GameObject.Instantiate(Resources.Load("Prefabs/CM vcam2", typeof(GameObject))) as GameObject;

        activeTool = 0;
       
        tools = new List<Tool>();
        for (int i = 0; i < 4; i++)
        {
            tools.Add(new Tool());
        }

        tools[0].InitTool(RequireListTool.Hammer, 100, 0);
        tools[1].InitTool(RequireListTool.Wrench, 100, 0);
        tools[2].InitTool(RequireListTool.Extincteur, 100, 10);
        tools[3].InitTool(RequireListTool.Welder, 100, 20);

        rb = GetComponent<Rigidbody2D>();

    }

    public void UpdatePlayer()
    {
        Move();

        Vector3 temp = new Vector3(transform.position.x, transform.position.y, -12);
        cinemachine.transform.position = temp;



        SwitchTool();

        Interact();
    
    }

    public void FixedUpdatePlayer()
    {

    }

    public void Interact()
    {
        if (InputManager.GetKeysInput().F)

            if (canRefill)
                tools[activeTool].FillEnergy();
            else if (canAnswer)
                CallerManager.Instance.caller.Hangup();
            else
            {
                List<Vector2Int> adjTiles = new List<Vector2Int>();
                RaycastHit2D hit;
                int layerMask = 1 << 9;
                hit = Physics2D.Raycast(transform.position, new Vector2(0, 0), Mathf.Infinity, layerMask);
                Room currentRoom = hit.transform.GetComponent<Room>();
                //adjTiles.Add(currentRoom.tilemap.WorldToCell(transform.position));

                for (int y = -1; y < 2; y++)
                {
                    for (int x = -1; x < 2; x++)
                    {
                        adjTiles.Add(new Vector2Int(currentRoom.tilemap.WorldToCell(transform.position).x + x, currentRoom.tilemap.WorldToCell(transform.position).y + y));
                    }
                }

                bool foundDamaged = false;

                for (int i = 0; i < adjTiles.Count && !foundDamaged; i++)
                {
                    Tiles t;
                    currentRoom.tiles.TryGetValue(adjTiles[i], out t);
                    //Debug.Log(t);
                    if (t != null && t.getIsDamaged())
                    {
                        tools[activeTool].Use(t);
                        foundDamaged = true;
                    }
                }

            }
    }

    bool isMoving = false;
    bool soundStarted = false;

    private void Move()
    {
        Vector2 dir = new Vector2(0, 0);

        if (InputManager.GetKeysInput().W) {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            dir += new Vector2(0, 1);
            isMoving = true;
           
        }
        if (InputManager.GetKeysInput().S) {
            transform.localEulerAngles = new Vector3(0, 0, 180);
            dir += new Vector2(0, -1);
            isMoving = true;
           
        }

        if (InputManager.GetKeysInput().A) {
            transform.localEulerAngles = new Vector3(0, 0, 90);
            dir += new Vector2(-1, 0);
            isMoving = true;
          
        }

        if (InputManager.GetKeysInput().D) {
            transform.localEulerAngles = new Vector3(0, 0, -90);
            dir += new Vector2(1, 0);
            isMoving = true;
          
        }
        if (isMoving && !soundStarted)
        {
            soundStarted = true;
            SoundManager.PlaySound(SoundManager.EnumSound.PlayerMove);

        }

        if (Input.GetKeyDown(KeyCode.O))
        {

           
            GameObject go = GameObject.Instantiate(Resources.Load("Prefabs/Spark_Particle"), transform.position, Quaternion.identity)as GameObject;
            GameObject.Destroy(go, 10);
        }

        InputManager.InputPkg pkg = InputManager.GetKeysInput();

        if (!pkg.A && !pkg.D && !pkg.S && !pkg.W) {

            isMoving = false;
            soundStarted = false;
            SoundManager.StopSound();
        }
        
        
        rb.velocity = dir * speed;
    }
    

    private void SwitchTool()
    {
        if (InputManager.GetKeysInput().tool1Pressed)
        {
           
            print("Hammer");
            activeTool = 0;
            UIManager.Instance.ChangeActiveTools((RequireListTool)activeTool);
            SoundManager.PlaySound(SoundManager.EnumSound.switchTool);
        }
        if (InputManager.GetKeysInput().tool2Pressed)
        {
            print("Wrench");
            activeTool = 1;
            UIManager.Instance.ChangeActiveTools((RequireListTool)activeTool);
            SoundManager.PlaySound(SoundManager.EnumSound.switchTool);

        }
        if (InputManager.GetKeysInput().tool3Pressed)
        {
            print("Extincteur");
            activeTool = 2;
            UIManager.Instance.ChangeActiveTools((RequireListTool)activeTool);
            SoundManager.PlaySound(SoundManager.EnumSound.switchTool);

        }
        if (InputManager.GetKeysInput().tool4Pressed)
        {
            print("Welder");
            activeTool = 3;
            UIManager.Instance.ChangeActiveTools((RequireListTool)activeTool);
            SoundManager.PlaySound(SoundManager.EnumSound.switchTool);

        }
    }
}
