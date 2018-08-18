using UnityEngine;
using Stores;

class Test : MonoBehaviour
{
    public void Jump()
    {
        Debug.Log("Jump");
    }

    public void Right()
    {
        Debug.Log("Right");
    }

    public void Left()
    {
        Debug.Log("Left");
    }

    public void GameStateChange(GameState state)
    {
        Debug.Log(state);
    }
}