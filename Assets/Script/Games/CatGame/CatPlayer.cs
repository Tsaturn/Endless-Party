using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CatPlayer : MonoBehaviour
{
    private int score = 0;
    public string ss = "Score: ";
    public TextMeshProUGUI tmp;
    public bool win = false;
    private float jumpForce = 8f;
    private bool onjump = true;

    private Rigidbody2D rb;
    public Collider2D[] col;
    public List<GameObject> roads;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Spawn", 0, 3);
    }

    private void Update()
    {
        jump();
        ss = "Score: " + score.ToString();
        tmp.text = ss;
        if (score >= 50)
        {
            win = true;
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject newroad = Instantiate(col[i].gameObject);
            newroad.GetComponent<CatObj>().speed = -(Random.value + 0.05f) * 3;
            newroad.transform.localScale = new Vector3(-(newroad.GetComponent<CatObj>().speed), newroad.transform.localScale.y);
            roads.Add(newroad);
        }
    }

    public void End()
    {
        ChangeCamera();
        //bonfire.GetComponent<Bonfire>().player.SetActive(true);
        //bonfire.GetComponent<Bonfire>().BonfireGame.SetActive(false);
        //Destroy(bonfire.GetComponent<Bonfire>().button);
        //bonfire.GetComponent<Bonfire>().player.GetComponent<Player>().Quest["Sigward"] = 1;
    }

    public void ChangeCamera()
    {
        //bonfire.GetComponent<Bonfire>().mainCamera = Camera.main;
    }
    public void score_inc()
    {
        score++;
    }

    private void EnableCol()
    {
        foreach (var item in col)
            item.GetComponent<Collider2D>().enabled = true;
    }
    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onjump)
        {
            foreach (var item in roads)
                item.GetComponent<Collider2D>().enabled = false;
            onjump = false;
            Invoke("EnableCol", 0.5f);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
