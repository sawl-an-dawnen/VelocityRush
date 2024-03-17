using System.Threading;
using UnityEditor;
using UnityEngine;


public class FinishLine : MonoBehaviour
{
    public string nextLevel;
    public float timer = 2f;
    public AudioClip victorySound;
    private SceneLoader sceneLoader;
    private GameManager gameManager;
    private LevelManager levelManager;
    private TimeTrial timeTrial;
    private AudioSource audioSource;
    private bool levelComplete = false;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
        timeTrial = levelManager.gameObject.GetComponent<TimeTrial>();
    }

    private void Update()
    {
        if (levelComplete) 
        {
            timer -= Time.deltaTime;
            if (timer <= 0) 
            {
                sceneLoader = GetComponent<SceneLoader>();
                sceneLoader.LoadScene(nextLevel);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            timeTrial.active = false;
            gameManager.CompleteLevel(levelManager.levelIndex - 1, timeTrial.timer);
            audioSource.PlayOneShot(victorySound);
            levelComplete = true;
            Destroy(gameObject.GetComponent<MeshCollider>());
        }
    }
}
