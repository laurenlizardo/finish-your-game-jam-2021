using UnityEngine;

namespace ggj
{
    public class ExitCollider : MonoBehaviour
    {
        [SerializeField] private InterfaceController _interfaceController;
        
        private void OnMouseUp()
        {
            _interfaceController.EndGame();
        }
    }
}