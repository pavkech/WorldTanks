#if UNITY_EDITOR
using System;
using UnityEngine;
using YG.Insides;

namespace YG
{
    public partial class InfoYG
    {
        [Tooltip(Langs.t_simulationInEditor)]
        public SimulationSettings Simulation = new SimulationSettings();

        [Serializable]
        public partial class SimulationSettings
        {
#if RU_YG2
            [HeaderYG("������ ���������", 5)]
#else
            [HeaderYG("Environment Data", 5)]
#endif
#if EnvirData_yg
            public YG2.Device device;
#endif
            public string language = "ru";

            [HeaderYG(Langs.advSimHeader, 5)]

            [Tooltip(Langs.t_advIntervalSimulation), Min(0)]
            public int advIntervalSimulation = 60;

            [Tooltip(Langs.t_advDurationAdv), Min(0)]
            public float durationAdv = 0.5f;

            [Tooltip(Langs.t_loadAdv), Min(0)]
            public float loadAdv = 0.0f;

#if UNITY_EDITOR
#if RU_YG2
            [Tooltip("������������� ������ ������ ��� ��������� �������.")]
#else
            [Tooltip("Click the check mark to simulate an error call when viewing ads.")]
#endif
            public bool testFailAds;
#endif
        }
    }
}
#endif