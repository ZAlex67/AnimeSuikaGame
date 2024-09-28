using UnityEngine;

public class ColliderInformer : MonoBehaviour
{
    public bool WasCombineIn {  get; set; }

    private bool _hasCollided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_hasCollided && !WasCombineIn)
        {
            _hasCollided = true;
            ThrowFruitController.Instance.CanThrow = true;
            ThrowFruitController.Instance.SpawnFruit(FruitSelector.Instance.NextFruit);
            FruitSelector.Instance.PickNextFruit();
            Destroy(this);
        }
    }
}