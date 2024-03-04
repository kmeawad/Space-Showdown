using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class PowerCells : MonoBehaviour
{
    public int availableCells;
    public int maxCells;
    public Image cellsBar;
    public float fillSpeed;
    public TextMeshProUGUI cellsText;

    private float timeSinceLastFill;

    // Start is called before the first frame update
    void Start()
    {
        availableCells = 0;
        cellsBar.fillAmount = 0;
        timeSinceLastFill = 0f;
        cellsText.text = availableCells.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(availableCells != maxCells)
        {
            timeSinceLastFill += Time.deltaTime;
            cellsBar.fillAmount = (float) Math.Min(1.0, timeSinceLastFill / fillSpeed);
            if (timeSinceLastFill >= fillSpeed)
            {
                timeSinceLastFill = 0f;
                availableCells += 1;
            }
        }

        cellsText.text = availableCells.ToString();
    }
}
