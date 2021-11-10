using UnityEngine;

namespace ggj
{
    public class ApartmentVent : InteractableItem
    {
        [SerializeField] private GameObject _briefcase;
        
        public override void Raise()
        {
            _briefcase.SetActive( true );   
        }

        private void Start()
        {
            _briefcase.SetActive( false );
        }
    }

}