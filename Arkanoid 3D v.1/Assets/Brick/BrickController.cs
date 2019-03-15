using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BrickController : MonoBehaviour
{
    public List<Sprite> spriteList;

    public int points;
    [SerializeField] [Range(0, 3)] private int health;

    protected SpriteRenderer spriteRenderer;

    [SerializeField][Range(0, 0.99f)] private float powerUpChance;
    public GameObject powerUp;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        points *= health + 1;
        SetSprite();
    }

    protected void TakeDamage()
    {
        health--;
        CheckHealth();
    }

    protected void CheckHealth()
    {
        if (health < 0) {
            GameObject gameController = GameObject.FindWithTag("GameController");
            gameController.SendMessage("BrickDestroyed", points);
            SpawnPowerUp();

            Destroy(gameObject);
        }
        SetSprite();
    }

    protected void SetSprite()
    {
        if (health >= 0 && spriteList != null) {
            spriteRenderer.sprite = spriteList[health];
        }
    }

    private void SpawnPowerUp()
    {
        if (UnityEngine.Random.Range(0, 1) < powerUpChance) {
            Instantiate(powerUp, transform.position, Quaternion.identity);
        }        
    }
}
