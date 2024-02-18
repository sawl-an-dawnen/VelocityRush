using UnityEngine;
using UnityEngine.UI;

public class EnableLevel : MonoBehaviour
{
    public int levelIndex;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //Debug.Log(gameManager.levels[levelIndex - 1]);
        if (levelIndex == 1 || gameManager.levels[levelIndex-2] == true) {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void Reset()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (levelIndex != 1)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
