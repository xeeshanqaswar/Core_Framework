using UnityEngine;

public interface IRootUi
{
    public Transform Root();
}

public class RootCanvas : MonoBehaviour, IRootUi
{
    public Transform Root() => transform;
}
