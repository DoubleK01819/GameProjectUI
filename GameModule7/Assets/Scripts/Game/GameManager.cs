using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private RecruitmentTimer harvestTimer;
    [SerializeField] private RecruitmentTimer eatingTimer;
    [SerializeField] private RecruitmentTimer raidTimer;
    [SerializeField] private Image farmerTimerImg;
    [SerializeField] private Image warriorsTimerImg;
    [SerializeField] private Image raidTimerImg;

    [SerializeField] private UnityEvent screenWin;
    [SerializeField] private UnityEvent screenLost;
    [SerializeField] private UnityEvent pauseGame;


    [SerializeField] private Text textHarvest;
    [SerializeField] private Text textFarmer;
    [SerializeField] private Text textWarriors;
    [SerializeField] private Text textScoreLevel;
    [SerializeField] private Text textAllFarmer;
    [SerializeField] private Text textAllWarriors;
    [SerializeField] private Text textCountEnemy;

    //Расход на юнитов
    [SerializeField] private int farmerPerPeasent;
    [SerializeField] private int warriorsPerPeasent;
    //Стоимость найма
    [SerializeField] private int farmerCost;
    [SerializeField] private int warriorsCost;

    [SerializeField] private float farmerCreatTime;
    [SerializeField] private float warriorsCreatTime;
    //Кол-во юнитов и еды
    [SerializeField] private int farmerCount;
    [SerializeField] private int harvestCount;
    [SerializeField] private int warriorsCount;

    [SerializeField] private Button warriorsButton;
    [SerializeField] private Button farmerButton;

    [SerializeField] private float raidMaxTime;
    [SerializeField] private int raidIncrease;
    [SerializeField] private int nextRaid;

    [SerializeField] private GameObject stars;
    [SerializeField] private GameObject starsLost;
    [SerializeField] private Sprite oneStar;
    [SerializeField] private Sprite twoStars;
    [SerializeField] private Sprite threeStars;

    [SerializeField] private AudioSource gameWin;

    private float warriorsTimer = -2;
    private float farmerTimer = -2;
    private int scoreLevel = 1;


    private void Start()
    {
        Time.timeScale = 1;
        UpdateText();
        CheckHarvestNumber();

    }

    private void Update()
    {

        if (raidTimer.Tick)
        {
            warriorsCount -= nextRaid;
            if (nextRaid > 0)
            {
                scoreLevel += 1;
                textScoreLevel.text = scoreLevel.ToString();
            }
            nextRaid += raidIncrease;
        }

        if (harvestTimer.Tick)
        {
            harvestCount += farmerCount * farmerPerPeasent;
        }

        if (eatingTimer.Tick)
        {
            harvestCount -= warriorsCount * warriorsPerPeasent;
        }

        CheckHarvestNumber();

        if (farmerTimer > 0)
        {
            farmerButton.interactable = false;
            farmerTimer -= Time.deltaTime;
            farmerTimerImg.fillAmount = farmerTimer / farmerCreatTime;
        }
        else if (farmerTimer > -1)
        {
            farmerTimerImg.fillAmount = 1;
            farmerButton.interactable = true;
            farmerCount += 1;
            farmerTimer = -2;
        }

        if (warriorsTimer > 0)
        {
            warriorsButton.interactable = false;
            warriorsTimer -= Time.deltaTime;
            warriorsTimerImg.fillAmount = warriorsTimer / warriorsCreatTime;
        }
        else if (warriorsTimer > -1)
        {
            warriorsTimerImg.fillAmount = 1;
            warriorsButton.interactable = true;
            warriorsCount += 1;
            warriorsTimer = -2;
        }

        UpdateText();
        ChangeImage();


        if (warriorsCount < 0)
        {
            screenLost.Invoke(); 
        }
    }

    public void CreatFarmer()
    {
        harvestCount -= farmerCost;
        farmerTimer = farmerCreatTime;
        farmerButton.interactable = false;
    }

    public void CreatWarriors()
    {
        harvestCount -= warriorsCost;
        warriorsTimer = warriorsCreatTime;
        warriorsButton.interactable = false;
    }

    private void UpdateText()
    {
        textCountEnemy.text = nextRaid.ToString();
        textFarmer.text = farmerCount.ToString();
        textHarvest.text = harvestCount.ToString();
        textWarriors.text = warriorsCount.ToString();
    }

    private void CheckHarvestNumber()
    {
        if (harvestCount - warriorsCost < 0)
        {
            warriorsButton.interactable = false;
        }
        else if (harvestCount - warriorsCost > 0)
        {
            warriorsButton.interactable = true;
        }

        if (harvestCount - farmerCost < 0)
        {
            farmerButton.interactable = false;
        }
        else if (harvestCount - farmerCost > 0)
        {
            farmerButton.interactable = true;
        }
    }

    public void Pause()
    {
        pauseGame.Invoke();
    }

    public void ChangeImage()
    {
        if (scoreLevel == 3)
        {
            stars.GetComponent<Image>().sprite = oneStar;
            starsLost.GetComponent<Image>().sprite = oneStar;
        }
        else if (scoreLevel == 7)
        {
            stars.GetComponent<Image>().sprite = twoStars;
            starsLost.GetComponent<Image>().sprite = twoStars;
        }
        else if (scoreLevel == 10)
        {
            stars.GetComponent<Image>().sprite = threeStars;
            screenWin.Invoke();
        }
    }

    public void TextValuesWin()
    {
        textAllWarriors.text = warriorsCount.ToString();
        textAllFarmer.text = farmerCount.ToString();
    }
}
