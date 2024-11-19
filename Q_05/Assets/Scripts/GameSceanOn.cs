using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceanOn : MonoBehaviour
{
    public void GotoGame()
    {
        GameManager.Intance.LoadScene(1);
    }

    public void GotoMain()
    {
        GameManager.Intance.LoadScene(0);
    }
}

