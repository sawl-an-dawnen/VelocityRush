using TMPro;
using UnityEngine;

public class TimeTrial : MonoBehaviour
{
    public bool timeTrialMode = false;
    public bool survivalMode = false;
    public string nextLevel;
    [HideInInspector]
    public bool active = true;
    public float timeLimit;
    public AudioClip victorySound;
    [HideInInspector]
    public float timer = 0f;
    private TextMeshProUGUI timerUI;
    private GameManager gameManager;
    private LevelManager levelManager;
    private float pause = 2f;
    private bool levelComplete = false;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        timerUI = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();
        //Debug.Log(UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset.GetType().Name);
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    void Update()
    {
        if (active)
        {
            timer += Time.deltaTime;
            timerUI.text = UpdateTimerDisplay(timer);
        }

        if ((timer >= timeLimit && timeTrialMode) || timer >= 3600f)
        {
            gameObject.GetComponent<SceneLoader>().LoadScene(); //gameover
        }
        if ((timer >= timeLimit && survivalMode))
        {
            Debug.Log("COMPLETE");
            gameManager.CompleteLevel(levelManager.levelIndex - 1, timer);
            levelComplete = true;
        }
        if (levelComplete)
        {
            audioSource.PlayOneShot(victorySound);
            pause -= Time.deltaTime;
            if (pause <= 0)
            {
                gameObject.GetComponent<SceneLoader>().LoadScene(nextLevel);
            }
        }
    }

    private string UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        string currentTime = string.Format("{00:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        return currentTime;
        //firstMinute.text = currentTime[0].ToString();
        //secondMinute.text = currentTime[1].ToString();
        //firstSecond.text = currentTime[2].ToString();
        //secondSecond.text = currentTime[3].ToString();
        //firstMilli.text = currentTime[4].ToString();
        //secondMilli.text = currentTime[5].ToString();
    }

}
