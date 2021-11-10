using UnityEngine;

namespace ggj
{
    public class ToggleableUI : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive( false );
        }
    }
}