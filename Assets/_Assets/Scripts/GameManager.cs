using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI[] itemCountTexts;
    public int[] itemCounts;
    public int coinCount = 0;
    public float spawnAreaMin = -44f;
    public float spawnAreaMax = 44f;
    public Transform _coinParent;
    public Button[] itemButtons;
    public int[] itemPrices;
    

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoin());
        coinCount = 10000;
        for (int i = 0; i < itemButtons.Length; i++)
        {
            int index = i; // Prevent closure issue
            itemButtons[i].onClick.AddListener(() => PurchaseItem(index));
        }
        UpdateItemCountsUI();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void UpdateItemCountsUI()
    {
        for (int i = 0; i < itemCountTexts.Length; i++)
        {
            itemCountTexts[i].text = $"{itemCounts[i]}";
        }
    }
    
    //--------------------Shop-System--------------------
    void PurchaseItem(int itemIndex)
    {
        if (coinCount >= itemPrices[itemIndex])
        {
            coinCount -= itemPrices[itemIndex];
            itemCounts[itemIndex]++;

            coinsText.text = $"Coins: {coinCount}";
            Debug.Log("Purchased Item " + (itemIndex + 1));
            UpdateItemCountsUI();
        }
        else
        {
            Debug.Log("Not enough currency to purchase Item " + (itemIndex + 1));
        }
    }    
    
    //--------------------Shop-System-Ends--------------------
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
