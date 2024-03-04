using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedUpCard : BasicAttackCard
{
    public float duration;
    public float speedMultiplier;

    private float initialPlayerSpeed;

    public override void Start()
    {
        base.Start();

        initialPlayerSpeed = player.GetComponent<PC_PlayerMovement>().moveSpeed;
    }

    public override void Update()
    {
        if (clicked)
        {
            //make sure that cooldown has finished before shooting again
            if (duration <= 0)
            {
                player.GetComponent<PC_PlayerMovement>().moveSpeed = initialPlayerSpeed;
                Destroy(gameObject);
            }
            else
                duration -= Time.deltaTime; // reduce the time remaining for the next bullet to shoot
        }
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();

        player.GetComponent<PC_PlayerMovement>().moveSpeed *= speedMultiplier;
    }
}
