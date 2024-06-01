using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public TextMeshProUGUI coinsText;
    public int coinCount = 0;
    public float spawnAreaMin = -44f;
    public float spawnAreaMax = 44f;
    public Transform _coinParent;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnCoin()
    {
        int x = Random.Range(1, 6);
        while (true)
        {
                    
            yield return new WaitForSeconds(x);
            // Calculate a random position within the spawn area
            Vector3 randomPosition = new Vector3(
                Random.Range(-44f, 44f),
                0.50f,
                Random.Range(-44f, 44f)
            );

            // Instantiate the object at the random position
            Instantiate(coinPrefab, randomPosition, Quaternion.identity,_coinParent);
                
        }
    }
}
