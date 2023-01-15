using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevionGames;

namespace MemorySculpture {

    public class MemoryController : MonoBehaviour
    {
        public string message;
        // public 
        // Start is called before the first frame update

        public RectTransform textRectTransform;
        public RectTransform textParentRectTransform;
        public CurvyText curvyText;
        public float spinSpeed = 10.2f;
        public MeshRenderer renderer;

        private List<AudioSource> audioComponents = new List<AudioSource>();

        void Start()
        {
            textParentRectTransform.gameObject.SetActive(false);
            var components = gameObject.GetComponents<AudioSource>();
            int i = 0;
            foreach (var comp in components) {
                audioComponents.Add(comp);
                Debug.Log(i);
                i++;
            }
            Focus();
        }

        // Update is called once per frame
        void Update()
        {
            gameObject.GetComponent<Transform>().LookAt(Camera.main.transform);
            // textRectTransform.rotation = Quaternion.Euler(0, 0, Time.time * spinSpeed);
        }

        public void SetParams(MemoryDatum datum) {
            message = datum.message;
            curvyText.text = message;
            float sum = datum.scores.Sad + datum.scores.Fear + datum.scores.Happy + datum.scores.Angry + datum.scores.Surprise;
            renderer.material.SetFloat("_purple", datum.scores.Fear * 3 + Random.Range(0, 1));
            renderer.material.SetFloat("_blue", datum.scores.Sad * 3 + Random.Range(0, 1));
            renderer.material.SetFloat("_yellow", datum.scores.Happy * 3 + Random.Range(0, 1));
            renderer.material.SetFloat("_red", datum.scores.Angry * 3 + Random.Range(0, 1));
            renderer.material.SetFloat("_pink", datum.scores.Surprise * 3 + Random.Range(0, 1));
            renderer.material.SetFloat("_scale", 4 + datum.scores.Angry * 2 + datum.scores.Happy * 2 - datum.scores.Sad * 1.8f - datum.scores.Fear * 1.8f);
            renderer.material.SetFloat("_saturation", sum * 3 + Random.Range(0, 1));
            renderer.material.SetFloat("_intensity", sum * 3 + Random.Range(0, 1));
            int i = 0;
            foreach (var comp in audioComponents) {
                if (i == 0) {
                    comp.volume = 0.05f * Random.Range(0, 1) + 0.05f * datum.scores.Angry;
                } else if (i == 1){
                    comp.volume = 0.05f * Random.Range(0, 1) + 0.05f * datum.scores.Happy;
                } else if (i == 2) {
                    comp.volume = 0.05f * Random.Range(0, 1) + 0.05f * datum.scores.Sad;
                } else if (i == 3) {
                    comp.volume = 0.05f * Random.Range(0, 1) + 0.05f * datum.scores.Angry;
                } else if (i == 4) {
                    comp.volume = 0.05f * Random.Range(0, 1) + 0.05f * datum.scores.Surprise;
                }
                i++;   
            }
        }

        public void Focus() {
            textParentRectTransform.gameObject.SetActive(true);
            foreach (var comp in audioComponents) {
                comp.Play();
            }
        }

        public void Unfocus() {
            textParentRectTransform.gameObject.SetActive(false);
            foreach (var comp in audioComponents) {
                comp.Stop();
            }
        }
    }
}

