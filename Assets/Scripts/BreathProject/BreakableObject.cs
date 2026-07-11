using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public float destroyDelay = 0f;

    public void Break()
    {
        Debug.Log(gameObject.name + " destruído!");

        Destroy(gameObject, destroyDelay);
    }
}
