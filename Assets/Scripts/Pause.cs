using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject pauseCanvas;
    public UnityEngine.UI.Slider xAxisSlider, yAxisSlider, musicSlider, sfxSlider;
    private GameManager gameManager;
    private AudioSource mainMusicSource;
    private bool paused = false;



    // Start is called before the first frame update
    void Start()
    {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            mainMusicSource = GameObject.FindGameObjectWithTag("GameMusic").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TriggerPause();
        }
    }

    private void OnPause()
    {
        TriggerPause();
    }

    public void TriggerPause() {
        paused = !paused;
        if (paused)
        {
            //freeze timer, player physics, call main pause function
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseCanvas.SetActive(true);
        }
        else 
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pauseCanvas.SetActive(false);
        }
    }

    public void ResetSettings() {
        gameManager.xSens = 50f;
        gameManager.ySens = 50f;
        gameManager.musicVolume = 50f;
        mainMusicSource.volume = .5f;
        gameManager.sfxVolume = 50f;
        xAxisSlider.value = 50f;
        yAxisSlider.value = 50f;
        musicSlider.value = 50;
        sfxSlider.value = 50f;
        gameManager.SaveSettings();
    }
}
