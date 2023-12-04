using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFactoryApplyToMaterial : MonoBehaviour
{
    ParticleSystemRenderer ps;
    private float value;
    private float m_scaleFactor;
    private float m_changedFactor;

    private void Awake()
    {
        ps = this.GetComponent<ParticleSystemRenderer>();
        value = ps.material.GetFloat("_NoiseScale");
        m_scaleFactor = 1;
    }

    // Update is called once per frame
    void Update()
    {
        m_changedFactor = VariousEffectsScene.m_graph_scenesizefactor;

        if(m_scaleFactor != m_changedFactor && m_changedFactor <= 1)
        {
            m_scaleFactor = m_changedFactor;
            if (m_scaleFactor <= 0.5f)
                ps.material.SetFloat("_NoiseScale", value * 0.25f);
            else
                ps.material.SetFloat("_NoiseScale", value * m_scaleFactor);
        }
    }
}
