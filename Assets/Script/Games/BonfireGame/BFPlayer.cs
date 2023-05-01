using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
public class BFPlayer : MonoBehaviour
{
    private int score = 0;
    public string ss = "Score: ";
    public TextMeshProUGUI tmp;
    private int live = 2;
    public GameObject[] livesObj = new GameObject[3];
    public bool win = false;
    public GameObject bonfire;
    private float jumpForce = 9f;
    private Rigidbody2D rb;
    public GameObject spawner;
    public Sprite sprite;
    public GameObject sun;
    public GameObject end;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("score_inc", 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score = 0;
        live_dec();
        foreach (var item in spawner.GetComponent<BFSpawn>().spawnList)
        {
            item.transform.position = new Vector2(-700, 50);
        }
    }
    private void Update()
    {
        jump();
        ss = "Score: " + score.ToString();
        tmp.text = ss;
        if (score >= 100)
        {
            win = true;
            sun.GetComponent<SpriteRenderer>().sprite = sprite;
            end.SetActive(true);
        }
    }

    public void End()
    {
        ChangeCamera();
        bonfire.GetComponent<Bonfire>().player.SetActive(true);
        bonfire.GetComponent<Bonfire>().BonfireGame.SetActive(false);
        Destroy(bonfire.GetComponent<Bonfire>().button);
        bonfire.GetComponent<Bonfire>().player.GetComponent<Player>().Quest["Sigward"] = 1;
    }
    public void live_dec()
    {
        if (live >= 0)
        {
            livesObj[live].SetActive(false);
            live--;
        }
        else
            if (!win)
        {
            Invoke("ChangeCamera", 6);
            bonfire.GetComponent<Bonfire>().End();
        }
    }

    public void ChangeCamera()
    {
        bonfire.GetComponent<Bonfire>().mainCamera = Camera.main;
        //bonfire.GetComponent<Bonfire>().gameCamera.enabled = false;
    }
    public void score_inc()
    {
        score++;
    }

    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rb.position.y <= 14)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
