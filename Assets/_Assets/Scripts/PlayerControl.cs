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
    
   
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    
}
