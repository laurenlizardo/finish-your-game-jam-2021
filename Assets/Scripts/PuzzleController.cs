using UnityEngine;
using UnityEngine.Events;

namespace ggj
{
    public class PuzzleController
    {
        public static UnityEvent OnHallwayKeypadSolved = new UnityEvent();
        public static UnityEvent OnHallwayDoorClicked = new UnityEvent();
        public static UnityEvent OnLaptopSolved = new UnityEvent();
    }
}