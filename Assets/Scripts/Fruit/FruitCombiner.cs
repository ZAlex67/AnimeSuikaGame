using UnityEngine;

public class FruitCombiner : MonoBehaviour
{
    private int _layerIndex;
    private FruitInfo _info;
    private int _layerGround = 4;

    private void Awake()
    {
        _info = GetComponent<FruitInfo>();
        //_layerIndex = gameObject.layer;
        _layerIndex = gameObject.GetComponent<FruitInfo>().FruitIndex;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.layer == _layerIndex)
        if (collision.gameObject.layer != _layerGround)
        {
            if (collision.gameObject.GetComponent<FruitInfo>().FruitIndex == _layerIndex)
            {
                FruitInfo info = collision.gameObject.GetComponent<FruitInfo>();

                if (info != null)
                {
                    int thisID = gameObject.GetInstanceID();
                    int otherID = collision.gameObject.GetInstanceID();

                    if (thisID > otherID)
                    {
                        GameManager.Instance.IncreaseScore(_info.PointsWhenAnnihilated);

                        if (_info.FruitIndex == FruitSelector.Instance._fruits.Length - 1)
                        {
                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }
                        else
                        {
                            Vector3 middlePosition = (transform.position + collision.transform.position) / 2f;
                            GameObject go = Instantiate(SpawnCombinedFruit(_info.FruitIndex), GameManager.Instance.transform);
                            go.transform.position = middlePosition;

                            ColliderInformer informer = go.GetComponent<ColliderInformer>();

                            if (informer != null)
                            {
                                informer.WasCombineIn = true;
                            }

                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }

    private GameObject SpawnCombinedFruit(int index)
    {
        GameObject go = FruitSelector.Instance._fruits[index + 1];

        return go;
    }
}