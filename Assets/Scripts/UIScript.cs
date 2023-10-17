using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] private Text hpText;
    [SerializeField] private Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "Życie: " + playerScript.healthPoints;
        if (playerScript.healthPoints <= 0)
        {
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
