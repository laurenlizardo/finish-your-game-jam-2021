using UnityEngine;

namespace ggj
{
    public class HallwayPlant : InteractableItem, IMovable
    {
        #region Abstract Overrides |====================================================================================
        public override void Raise()
        {
            if ( _hasTouchCount && _currentTouchCount < _maxTouchCount )
            {
                _currentTouchCount++;
                Move();
            }
        }
        #endregion Abstract Overrides |=================================================================================

        #region Interface Implementations |=============================================================================
        public void Move()
        {
            transform.position = new Vector3(transform.position.x - .25f,
                transform.position.y, transform.position.z);
        }
        #endregion Interface Implementations |==========================================================================
    }
}