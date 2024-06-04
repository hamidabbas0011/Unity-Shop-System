using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerControl : MonoBehaviour
{
    public GameManager _gameManager;
    public GameObject gameManagerObject;
    private float _speed = 10.0f;
    public static bool isGamePaused = false;
    public GameObject shopMenuUI;
   
    // Start is called before the first frame update
    void Start()
    {
        shopMenuUI.SetActive(false);
        transform.position = new Vector3(0, 2, 0);   
        _gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime*_speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime*_speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime*_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime*_speed);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            shopMenuUI.SetActive(false);
            Time.timeScale = 1; //Freeze the game
            isGamePaused = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            _gameManager.coinCount++;
            Destroy(other.GameObject());
            _gameManager.coinsText.text = $"Coins: {_gameManager.coinCount}";
            Debug.LogWarning(_gameManager.coinCount);
            Debug.LogWarning("Coin Collected");
        }
        if (other.CompareTag("Shop"))
        {
            Debug.LogWarning("Shop Entered");
            shopMenuUI.SetActive(true);
            Time.timeScale = 0; //Freeze the game
            isGamePaused = true;
        }
    }

    
}
