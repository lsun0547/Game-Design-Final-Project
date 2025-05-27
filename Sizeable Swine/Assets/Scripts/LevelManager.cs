using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI foodText;
    private int maxFood;
    private int foodRemaining;
    public string levelNameToLoad;

    // Start is called before the first frame update
    void Start()
    {
        maxFood = GameObject.FindGameObjectsWithTag("Food").Length;
        foodRemaining = maxFood;
        foodText.text = "Food Remaining: " + foodRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if(foodRemaining <= 0)
        {
            SceneManager.LoadScene(levelNameToLoad);
        }
    }

    public void RemoveFood()
    {
        foodRemaining -= 1;
        foodText.text = "Food Remaining: " + foodRemaining;
    }
}
