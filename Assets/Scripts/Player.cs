using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerController playerController;
    float health;

    // Start is called before the first frame update
    void Start()
    {
        // ignores collision between player and enemies
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"));
        health = 10;
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()

    {

    }

    private void FixedUpdate()
    {
        playerController.HandleMovement();
    }

    public void Hurt(float damage)
    {
        var currHealth = this.health;
        currHealth -= damage;
        if (currHealth <= 0)
        {
            this.GameOver();
        }
    }

    private void GameOver()
    {

    }
}
