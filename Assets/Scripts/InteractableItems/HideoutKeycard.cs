
using UnityEngine;

namespace ggj
{
    public class HideoutKeycard : InteractableItem
    {
        [SerializeField] private HideoutDoors _hideOutDoors;
        [SerializeField] private GameObject _specialFX;
        [SerializeField] private InterfaceController _interfaceController;

        public override void Raise()
        {
            _hideOutDoors.CloseDoors();
            _hideOutDoors.ShowExit();
            _specialFX.SetActive( true );
            gameObject.SetActive( false );
            
            _interfaceController.EndGame();
        }

        private void Start()
        {
            _specialFX.SetActive( false );
        }
    }
}