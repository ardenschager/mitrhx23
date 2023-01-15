using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace MemorySculpture {
    public class VfxInterface : MonoBehaviour
    {
        public VisualEffect myEffect;
        // private Texture2D tex0;
        // private Texture2D tex1;

        float avgAngry = 0.0f;
        float avgFear = 0.0f;
        float avgHappy = 0.0f;
        float avgSad = 0.0f;
        float avgSurprise = 0.0f;
        
        // Start is called before the first frame update
        void Start()
        {
            myEffect = GetComponent<VisualEffect>();
            // tex0 = new Texture2D(128, 128);
            // tex1 = new Texture2D(128, 128);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        // arrange memories in spiral pattern
        public void InitFromList(MemoryDatum[] memories) {
            int numMems = memories.Length;
            for (int i = 0; i < numMems; i++) {
                // AddMemory(memories[i], GetPosition(i, numMems, 0.0f));
                avgAngry += memories[i].scores.Angry;
                avgFear += memories[i].scores.Fear;
                avgHappy += memories[i].scores.Happy;
                avgSad += memories[i].scores.Sad;
                avgSurprise += memories[i].scores.Surprise;
            }
            avgAngry /= numMems;
            avgFear /= numMems;
            avgHappy /= numMems;
            avgSad /= numMems;
            avgSurprise /= numMems;
            myEffect.SetFloat("Angry", avgAngry + Random.Range(0.0f, 0.33f));
            myEffect.SetFloat("Fear", avgFear + Random.Range(0.0f, 0.33f));
            myEffect.SetFloat("Happy", avgHappy + Random.Range(0.0f, 0.33f));
            myEffect.SetFloat("Sad", avgSad + Random.Range(0.0f, 0.33f));
            myEffect.SetFloat("Surprise", avgSurprise + Random.Range(0.0f, 0.33f));
        }

        // public void AddNewMemory(string text, )
    }
}

