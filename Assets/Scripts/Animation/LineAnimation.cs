using System.Collections;
using UnityEngine;

namespace Aviator
{
    public class LineAnimation : MonoBehaviour
    {
        [SerializeField] private Transform startPos;
        [SerializeField] private Transform xEndPos;
        [SerializeField] private Transform yEndPos;
        [SerializeField] private Color fillColor = Color.blue;
        [SerializeField] private LineRenderer xLine;
        [SerializeField] private LineRenderer yLine;

        private void Start()
        {
            
        }

        public void DrawLinesForward()
        {
            
        }        
        
        public void DrawLinesBackward()
        {
            
        }
        
        private IEnumerator DrawForwardOnX()
        {
            yield return null;
        }

        private IEnumerator DrawForwardOnY()
        {
            yield return null;
        }

        private IEnumerator DrawBackwardOnX()
        {
            yield return null;
        }

        private IEnumerator DrawbackwardOnY()
        {
            yield return null;
        }
    }
}