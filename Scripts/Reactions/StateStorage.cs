using UnityEngine;
public class StateStorage : MonoBehaviour
{
    public enum State { free, chained, hungry, tired, sleepy }
    public State currentState = State.chained;
    public void BlowChains()
    {
        if (currentState == State.chained)
        {
            currentState = State.free;
        }
    }
}