using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class GenerateNetwork : MonoBehaviour
{
    private ParticleSystem ps;
    private Dictionary<string, ParticleSystem.Particle> particles;
    private Dictionary<string, Color32> particleColor;
    private Dictionary<string, Color32> cat_color;
    private Dictionary<string, List<string>> network;
    private List<GameObject> lines;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize Color Dictionary
        InitializeColors();

         // Get Particle System
        ps = GetComponent<ParticleSystem>();
        
        lines = new List<GameObject>();

        particles = new Dictionary<string, ParticleSystem.Particle>();
        particleColor = new Dictionary<string, Color32>();

        particles = InitializeNetwork(500);

        // Start network with the particles from the blood dataset
        var main = ps.main;
        main.maxParticles = particles.Values.Count();
        ps.SetParticles(particles.Values.ToArray());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeColors()
    {
        // Cluster colours
        cat_color = new Dictionary<string, Color32>
        {
            { "blue", new Color32(0, 0, 255, 255) },
            { "white", new Color32(255, 255, 255, 255) },
            { "yellow", new Color32(255, 255, 0, 255) },
            { "cyan", new Color32(0, 255, 255, 255) },
            { "lightcyan", new Color32(244, 255, 255, 255) },
            { "darkgreen", new Color32(0, 128, 0, 255) },
            { "darkgrey", new Color32(50, 50, 50, 255) },
            { "darkred", new Color32(128, 0, 0, 255) },
            { "darkturquoise", new Color32(0, 128, 128, 255) },
            { "green", new Color32(0, 255, 0, 255) },
            { "grey60", new Color32(128, 128, 128, 255) },
            { "magenta", new Color32(255, 0, 255, 255) },
            { "midnightblue", new Color32(0, 0, 128, 255) },
            { "lightyellow", new Color32(255, 255, 128, 255) },
            { "pink", new Color32(255, 128, 255, 255) },
            { "purple", new Color32(128, 0, 128, 255) },
            { "violet", new Color32(238, 130, 238, 255) },
            { "saddlebrown", new Color32(139, 69, 19, 255) },
            { "brown", new Color32(165, 42, 42, 255) },
            { "tan", new Color32(210, 180, 140, 255) },
            { "salmon", new Color32(233, 150, 122, 255) },
            { "greenyellow", new Color32(173, 255, 47, 255) },
            { "turquoise", new Color32(64, 224, 208, 255) },
            { "darkorange", new Color32(255, 140, 0, 255) },
            { "royalblue", new Color32(0, 35, 102, 255) },
            { "crimsom", new Color32(220, 20, 60, 255) }
        };
    }

    private Dictionary<string, ParticleSystem.Particle> InitializeNetwork(int numParticles){
        // We load the network and categories files and save the information in arrays
        Dictionary<string, List<string>> particle_relations = new Dictionary<string, List<string>>();
        Dictionary<string, ParticleSystem.Particle> particleDict = new Dictionary<string, ParticleSystem.Particle>();

        int numColors = 5;

        for(int cat = 0; cat < numColors; cat++) {
            Color32 color = cat_color.ElementAt(cat).Value;
            
            for(int particle = 0; particle < numParticles; particle++) {
                ParticleSystem.Particle new_particle = new ParticleSystem.Particle
                {
                    remainingLifetime = 100000.0f,
                    startLifetime = 100000.0f,
                    startSize = 0.1f,
                    startColor = color,
                    position = new Vector3(UnityEngine.Random.value * 50, UnityEngine.Random.value * 10, UnityEngine.Random.value * 50)
                };
                particleDict[particle.ToString() + color] = new_particle;
                particleColor[particle.ToString() + color] = color;
            }
        }
        
        // TODO Edges

        //return particlesReal;
        return particleDict;
    }
}
