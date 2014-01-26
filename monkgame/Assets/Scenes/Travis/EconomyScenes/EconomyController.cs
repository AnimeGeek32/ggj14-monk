using UnityEngine;
using System.Collections;

public class EconomyController : MonoBehaviour
{
    public float Timer_Fruit = 3f;
    public float PlayerHealthDecreaseTime_Fish = 3f;
    public int PlayerHealthDecreaseBy_Fish = 1;
    public int PlayerHealthIncreaseBy_Fish = 2;
    public int PlayerHealth_Fish = 50;
    public int PlayerHealth_OtherFish = 50;
    public int PlayerHealthDecreaseBy_OtherFish = 1;
    public int PlayerHealthIncreaseBy_OtherFish = 2;

    public GUIText displayText;
    public static EconomyController Current;

    private GameObject fruit;
    private float _timer_fruit;
    private float _playerTimer_fish;

    // Use this for initialization
    void Start()
    {
        Current = this;
        fruit = Resources.Load<GameObject>("fruit");
        _timer_fruit = 0f;
        _playerTimer_fish = 0f;
        SetDisplayText();
    }

    // Update is called once per frame
    void Update()
    {

        if (_timer_fruit >= Timer_Fruit)
        {
            Vector3 randomDrop = new Vector3(Random.Range(-4.5f, 4.5f), 0.7f, 5f);
            Instantiate(fruit, randomDrop, Quaternion.identity);
            _timer_fruit = 0f;
        }

        if (_playerTimer_fish >= PlayerHealthDecreaseTime_Fish)
        {
            PlayerHealth_OtherFish -= PlayerHealthDecreaseBy_OtherFish;
            PlayerHealth_Fish -= PlayerHealthDecreaseBy_Fish;
            _playerTimer_fish = 0f;
            SetDisplayText();
        }

        _playerTimer_fish += Time.deltaTime;
        _timer_fruit += Time.deltaTime;
    }

    public void PlayerAteTheFruit()
    {
        PlayerHealth_Fish += PlayerHealthIncreaseBy_Fish;
        SetDisplayText();
    }

    public void FishAteTheFruit()
    {
        PlayerHealth_OtherFish += PlayerHealthIncreaseBy_OtherFish;
        SetDisplayText();
    }

    void SetDisplayText()
    {
        displayText.text =
            string.Format("Player Health: {0} | Other Fish Health: {1}",
                EconomyController.Current.PlayerHealth_Fish,
                EconomyController.Current.PlayerHealth_OtherFish);
    }
}