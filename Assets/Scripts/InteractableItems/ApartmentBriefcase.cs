using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ggj
{
    public class ApartmentBriefcase : InteractableItem
    {
        [SerializeField] private GameObject _lid;
        private Quaternion _lidRotation = Quaternion.Euler( 180, 0, 0 );
        [SerializeField] private GameObject _laptop;
        
        public override void Raise()
        {
            _lid.transform.localRotation = _lidRotation;
            _laptop.SetActive( true );
            gameObject.SetActive( false );
        }
        
        private void Start()
        {
            _lid.transform.localRotation = Quaternion.identity;
            _laptop.SetActive( false );
        }
    }
}
