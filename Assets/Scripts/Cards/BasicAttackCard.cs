using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasicAttackCard : MonoBehaviour
{
    public float fireRate;
    public int numberOfBullets;
    public TextMeshPro costText;
    public int cost;
    public GameObject bulletPrefab;

    protected GameObject player;
    protected GameObject playerPowerCells;
    protected GameObject cardsManager;

    protected float _timeRemaining;
    protected int timesShot;
    protected bool clicked;

    // Start is called before the first frame update
    public virtual void Start()
    {
        timesShot = 0;
        clicked = false;
        costText.text = cost.ToString();
        player = GameObject.Find("Player");

        playerPowerCells = GameObject.Find("Power Cells");
        cardsManager = GameObject.Find("Deck Holder");
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(clicked)
        {
            //make sure that cooldown has finished before shooting again
            if (_timeRemaining <= 0)
            {
                Transform bulletSpawner = player.transform.Find("Bullet Spawner").gameObject.transform;
                instantiateBullet(bulletSpawner);
                _timeRemaining = fireRate;
                timesShot += 1;

                if (timesShot == numberOfBullets)
                {
                    Destroy(gameObject);
                }
            }
            else
                _timeRemaining -= Time.deltaTime; // reduce the time remaining for the next bullet to shoot
        }
    }

    public virtual void OnMouseDown()
    {
        int availableCells = playerPowerCells.GetComponent<PowerCells>().availableCells;
        if(availableCells >= cost){
            _timeRemaining = 0;
            timesShot = 0;
            clicked = true;

            playerPowerCells.GetComponent<PowerCells>().availableCells -= cost;
            cardsManager.GetComponent<CardsManager>().ReplaceDestroyedCard(gameObject);
        }
        
    }

    public virtual void instantiateBullet(Transform bulletSpawner)
    {
        //create bullet gameobject
        Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
    }

}
