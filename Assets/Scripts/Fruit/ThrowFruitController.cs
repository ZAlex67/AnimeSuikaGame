using UnityEngine;

public class ThrowFruitController : MonoBehaviour
{
    private const float ExtraWidth = 0.02f;

    public static ThrowFruitController Instance;

    public GameObject CurrentFruit { get; set; }

    [SerializeField] private Transform _fruitTransform;
    [SerializeField] private Transform _parentAfterThrow;
    [SerializeField] private FruitSelector _selector;

    private PlayerController _playerController;

    private Rigidbody2D _rigidbody;
    private CircleCollider2D _circleCollider;

    public Bounds Bounds { get; private set; }

    public bool CanThrow { get; set; } = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();

        SpawnFruit(_selector.PickRandomFruitForThrow());
    }

    private void Update()
    {
        if (UserInput._isThrowPressed && CanThrow)
        {
            SpriteIndex index = CurrentFruit.GetComponent<SpriteIndex>();
            Quaternion rot = CurrentFruit.transform.rotation;

            GameObject go = Instantiate(FruitSelector.Instance._fruits[index.Index], CurrentFruit.transform.position, rot);
            go.transform.SetParent(_parentAfterThrow);

            Destroy(CurrentFruit);

            CanThrow = false;
        }
    }

    public void SpawnFruit(GameObject fruit)
    {
        GameObject go = Instantiate(fruit, _fruitTransform);
        CurrentFruit = go;
        _circleCollider = CurrentFruit.GetComponent<CircleCollider2D>();
        Bounds = _circleCollider.bounds;

        _playerController.ChangeBoundary(ExtraWidth);
    }
}