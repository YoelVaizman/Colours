
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManeger gameManeger;

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            gameManeger.completeLevel();

        }
    }
}
