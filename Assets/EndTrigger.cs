
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    //public GameManeger gameManeger;

    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.name + " triggered me");
    }
}
