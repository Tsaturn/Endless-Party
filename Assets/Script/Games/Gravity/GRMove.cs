using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GRMove : MonoBehaviour
{
    float speed = -2;
    float temp = -9;
    int score = 0;
    bool enJump = true;
    public GameObject deathMenu;
    public TextMeshProUGUI text;
    public SpriteRenderer gravity;
    Color color;
    private int live = 2;
    public GameObject[] livesObj = new GameObject[3];
    public bool win = false;
    public GameObject endbut;
    public GRSpawnFood spawn1;
    public GRSpawnRoad spawn2;
    public Cat catEnd;
    private void Start()
    {
        color = gravity.color;
    }
    private void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = 0;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        speed = temp;
    }
    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space) && enJump)
        {
            GetComponent<SpriteRenderer>().flipY = !GetComponent<SpriteRenderer>().flipY;
            temp *= -1;
            speed = temp;
            enJump = false;
            color.a = 0.5f;
            gravity.color = color;
            Invoke("JumpEnabled", 0.9f);
        }
    }

    private void JumpEnabled()
    {
        color.a = 1f;
        gravity.color = color;
        enJump = true;
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Food")
        {
            ScoreInc();
        }
        if (col.tag == "PlayerDestr")
        {
            live_dec();
        }

    }
    public void End()
    {
        spawn1.CancelInvoke("Spawn");
        spawn2.CancelInvoke("Spawn");
        ChangeCamera();
        catEnd.player.SetActive(true);
        if (win)
            catEnd.count = 777;
        else
        {
            catEnd.count = 666;
            catEnd.Dialog();
            catEnd.player.GetComponent<AudioSource>().enabled = false;
        }
        catEnd.GRCatGame.SetActive(false);
    }
    public void ChangeCamera()
    {
        catEnd.mainCamera = Camera.main;
        //catEnd.gameCamera.enabled = false;
    }

    public void ScoreInc()
    {
        score++;
        text.text = "Score: " + score.ToString();
        if (score >= 40) { win = true; endbut.SetActive(true); }
    }

    public void live_dec()
    {
        transform.position = new Vector3(-70, transform.position.y, transform.position.z);
        speed = System.Math.Sign(speed) * (System.Math.Abs(speed) - 8);
        if (live >= 0)
        {
            livesObj[live].SetActive(false);
            live--;
        }
        else
            if (!win)
        {
            End();
        }
    }
}
