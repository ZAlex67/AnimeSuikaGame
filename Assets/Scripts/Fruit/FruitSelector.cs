using UnityEngine;
using UnityEngine.UI;

public class FruitSelector : MonoBehaviour
{
    public static FruitSelector Instance;

    public GameObject[] _fruits;
    public GameObject[] _noPhysicsFruits;
    public int _highestStartingIndex = 3;

    [SerializeField] private Image _nextFruitImage;
    [SerializeField] private Sprite[] _fruitSprites;

    public GameObject NextFruit { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        PickNextFruit();
    }

    public GameObject PickRandomFruitForThrow()
    {
        int randomIndex = Random.Range(0, _highestStartingIndex + 1);

        if (randomIndex < _noPhysicsFruits.Length)
        {
            GameObject randomFruit = _noPhysicsFruits[randomIndex];

            return randomFruit;
        }

        return null;
    }

    public void PickNextFruit()
    {
        int randomIndex = Random.Range(0, _highestStartingIndex + 1);

        if (randomIndex < _fruits.Length)
        {
            GameObject nextFruit = _noPhysicsFruits[randomIndex];
            NextFruit = nextFruit;
            _nextFruitImage.sprite = _fruitSprites[randomIndex];
        }
    }
}