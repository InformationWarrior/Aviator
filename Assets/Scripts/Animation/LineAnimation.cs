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
        [SerializeField] private LineRenderer[] lineRenderers;
        private readonly float lineWidth = 0.03f;
        private readonly float drawingSpeed = 0.5f;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            foreach (var lineRenderer in lineRenderers)
            {
                lineRenderer.positionCount = 2;
                lineRenderer.startWidth = lineWidth;
                lineRenderer.enabled = false;
            }
        }

        public void DrawLinesForward()
        {
            StartCoroutine(Forward());
        }

        public void DrawLinesBackward()
        {
            StartCoroutine(Backward());
        }

        private IEnumerator Forward()
        {
            Vector3 startPosition = startPos.position;
            Vector3 targetXPosition = xEndPos.position;
            Vector3 targetYPosition = yEndPos.position;

            Vector3 lerpedXPosition;
            Vector3 lerpedYPosition;
            float elapsedTime = 0f;

            lineRenderers[0].SetPosition(0, startPosition);
            lineRenderers[1].SetPosition(0, startPosition);

            foreach (var lineRenderer in lineRenderers)
            {
                lineRenderer.enabled = true;
                lineRenderer.startColor = fillColor;
                lineRenderer.endColor = fillColor;
            }

            while (elapsedTime < 1f)
            {
                lerpedXPosition = Vector3.Lerp(startPosition, targetXPosition, elapsedTime);
                lerpedYPosition = Vector3.Lerp(startPosition, targetYPosition, elapsedTime);

                lineRenderers[0].SetPosition(1, lerpedXPosition);
                lineRenderers[1].SetPosition(1, lerpedYPosition);

                elapsedTime += Time.deltaTime * drawingSpeed;
                yield return null;
            }

            lineRenderers[0].SetPosition(1, targetXPosition);
            lineRenderers[1].SetPosition(1, targetYPosition);
        }

        private IEnumerator Backward()
        {
            Vector3 startPosition = startPos.position;
            Vector3 targetXPosition = xEndPos.position;
            Vector3 targetYPosition = yEndPos.position;

            Vector3 lerpedXPosition;
            Vector3 lerpedYPosition;
            float elapsedTime = 0f;

            lineRenderers[0].SetPosition(0, startPosition);
            lineRenderers[1].SetPosition(0, startPosition);

            foreach (var lineRenderer in lineRenderers)
            {
                lineRenderer.enabled = true;
                lineRenderer.startColor = fillColor;
                lineRenderer.endColor = fillColor;
            }
            
            while (elapsedTime < 1f)
            {
                lerpedXPosition = Vector3.Lerp(targetXPosition, startPosition, elapsedTime);
                lerpedYPosition = Vector3.Lerp(targetYPosition, startPosition, elapsedTime);

                lineRenderers[0].SetPosition(1, lerpedXPosition);
                lineRenderers[1].SetPosition(1, lerpedYPosition);

                elapsedTime += Time.deltaTime * drawingSpeed;
                yield return null;
            }

            lineRenderers[0].SetPosition(1, startPosition);
            lineRenderers[1].SetPosition(1, startPosition);
        }
    }
}