using UnityEngine;

public class FruitInfo : MonoBehaviour
{
    public int FruitIndex = 0;
    public int PointsWhenAnnihilated = 1;
    public float FruitMass = 1f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.mass = FruitMass;
    }
}