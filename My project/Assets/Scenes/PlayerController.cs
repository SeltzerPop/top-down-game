using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sr;
    public Sprite uparrow;
    public Sprite leftarrow;
    public Sprite rightarrow;
    public Sprite downarrow;
    public bool hasKey;
    public Vector2 spawnPosition1;
    public Vector2 spawnPosition2;
    public static PlayerController instance;

    //public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (instance !=null)
        {
            Destroy(gameObject);
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
            sr.sprite = rightarrow;
        }

        if (Input.GetKey("a"))
        {
            newPosition.x -= speed;
            sr.sprite = leftarrow;
        }

        if (Input.GetKey("w"))
        {
            newPosition.y += speed;
            sr.sprite = uparrow;
        }

        if (Input.GetKey("s"))
        {
            newPosition.y -= speed;
            sr.sprite = downarrow;
        }

        transform.position = newPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if colliding with a game object with specific tag
        if (collision.gameObject.tag.Equals("door1"))
        {
            Debug.Log("change scene");
            SceneManager.LoadScene("Scene2");
            transform.position = spawnPosition1;
        }
        if (collision.gameObject.tag.Equals("door2"))
        {
            Debug.Log("change scene");
            SceneManager.LoadScene("Scene1");
            transform.position = spawnPosition2;
        }

        if (collision.gameObject.tag.Equals("key"))
        {
            Debug.Log("obtained Key");
            hasKey = true;
        }

        if (collision.gameObject.tag.Equals("exit") && hasKey == true)
        {
            Debug.Log("escaped:");
            SceneManager.LoadScene("Ending");
            {
                Destroy(gameObject);
            }
            instance = this;
        }
    }
}
