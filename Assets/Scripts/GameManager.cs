using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region public.
    public static GameManager instance;
    public List<animationEnemy> enemyList;
    public List<WindMillAnimation> windMillList;
    public TowerTypeListSO TowerTypeListSO { get { return towerTypeListSO; } }
    public GameObject wheelThree;
    public GameObject wheelTwo;
    public bool isWheelThreeActive;
    public bool isWeelTwoActive;
    public GameObject arrow;
    [SerializeField]
    public int HealthPoints;
    [SerializeField]
    public TextMeshProUGUI Health;
    [SerializeField]
    public int Coins;
    [SerializeField]
    public TextMeshProUGUI CoinText;




    #endregion


    #region private.
    [SerializeField]
    private TowerTypeListSO towerTypeListSO;
    [SerializeField]
    private GameObject EndScreen;
    [SerializeField]
    private GameObject PauseScreen;
    [SerializeField]
    private GameObject WinScreen;
    private int TotalNumberOfEnenmies = 0;



    // [SerializeField]
    // private WheelSO wheelSO;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        SetUpWheels();
        Health.SetText(HealthPoints.ToString());
        CoinText.SetText(Coins.ToString());



    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].OnUpdate();
        }
        for (int i = 0; i < windMillList.Count; i++)
        {
            windMillList[i].OnUpdate();
        }

    }

    public void AddNumberOfEnemies(int number)
    {
        TotalNumberOfEnenmies += number;
    }
    public void UpdateNumberOfEnemis()
    {
        TotalNumberOfEnenmies--;
        if (TotalNumberOfEnenmies <= 0)
        {
            Time.timeScale = 0;
            WinScreen.SetActive(true);
        }
    }

    void SetUpWheels()
    {
        wheelThree = Instantiate(wheelThree);
        wheelThree.SetActive(false);
        isWheelThreeActive = false;
        wheelTwo = Instantiate(wheelTwo);
        wheelTwo.SetActive(false);
        isWeelTwoActive = false;
    }

    public void UpdateLifePoints()
    {
        HealthPoints--;
        Health.SetText(HealthPoints.ToString());
        if (HealthPoints <= 0)
        {
            EndScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void UpdateCoins(int value)
    {
        Coins += value;
        CoinText.SetText(Coins.ToString());
    }
    public void UpdateCoinsAfterBuild(int value)
    {
        Coins -= value;
        CoinText.SetText(Coins.ToString());
    }

    public void RestartLvl()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void PauseGame()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void LoadNextLvl()
    {
        
        if(SceneManager.GetActiveScene().buildIndex< SceneManager.sceneCountInBuildSettings-1)
        {
           
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        else
        {
            GoToMainMenu();
        }
    }
}
