using UnityEngine;

namespace Redress.Gameplay.Platforms
{
    public class ParallaxManager : MonoBehaviour
    {
        [System.Serializable] 
        public struct BackgroundGroup
        {
            public GameObject[] SpritesLayers;
            public int ManyspritesMoveSameTime;
            public float distancePerLayer;
            public float _speed;

            private float _startPos;
            private float _endPos;
            private float _distancePerLayer;

            private int[] currents;

            public void Init(float startPos,float endPos,int groupIndex)
            {
                _distancePerLayer = distancePerLayer;
                currents = new int[ManyspritesMoveSameTime];
                _startPos = startPos;
                _endPos = endPos;
                ResetGroup(groupIndex);
            }

            public void UpdateGroup()
            {
                MoveLayers();
            }

            private void MoveLayers()
            {
                if (SpritesLayers == null) return;
                for (int i = 0; i < currents.Length; i++)
                {
                    if (currents[i] >= SpritesLayers.Length) continue;
                    SpritesLayers[currents[i]].transform.localPosition += Vector3.left * _speed; // muevo todas las layers lo mismo
                    if (SpritesLayers[currents[i]].transform.localPosition.x<_endPos)
                    {
                        SpritesLayers[currents[i]].transform.localPosition = Vector3.right * _startPos + Vector3.up * SpritesLayers[currents[i]].transform.localPosition.y;
                        SpritesLayers[currents[i]].SetActive(false);
                        if (currents[i] + currents.Length < SpritesLayers.Length)
                            currents[i] += currents.Length;
                        else if (currents[i] + currents.Length == SpritesLayers.Length)
                            currents[i] = 0;
                        else
                            currents[i] = 0 + SpritesLayers.Length - currents[i];
                        SpritesLayers[currents[i]].SetActive(true);
                    }
                }
            }
            private void ResetGroup(int grupoIndex)
            {
                for (int i = 0; i < SpritesLayers.Length; i++)
                {
                    SpritesLayers[i].SetActive(false);
                }
                for (int i = 0; i < currents.Length; i++)
                {
                    if (currents[i] >= SpritesLayers.Length) continue;
                    currents[i] = i;
                }
                for (int i = 0; i < currents.Length; i++)
                {
                    if (currents[i] >= SpritesLayers.Length) continue;
                    SpritesLayers[currents[i]].SetActive(true);
                    SpritesLayers[currents[i]].transform.localPosition = (Vector3.right * _startPos) + (Vector3.right * _distancePerLayer * i) + Vector3.up * grupoIndex;
                }
            }
        }

        [SerializeField] private BackgroundGroup[] groups;
        [SerializeField] private float _startPos;
        [SerializeField] private float _endPos;
        

        private void Start()
        {
            for (int i = 0; i < groups.Length; i++)
            {
                groups[i].Init(_startPos, _endPos, i);
            }
        }
        private void Update()
        {
            UpdateBackground();
        }

        public void UpdateBackground()
        {
            for (int i = 0; i < groups.Length; i++)
            {
                groups[i].UpdateGroup();
            }
        }
    }
}
