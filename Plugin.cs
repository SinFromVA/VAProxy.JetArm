using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JetArm
{
    [BepInPlugin("SenGotHisLeftArm", "Jet Arm Attachment", "1.0.0")]
    public class AddLeftArm : BaseUnityPlugin
    {
        private void Awake()
        {
            SceneManager.sceneLoaded += this.OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "DaDemo")
            {
                this.s105 = GameObject.Find("S-105");
                if (this.s105 != null)
                {
                    Transform transform = this.s105.transform.Find("ROOT/Hips/Spine/Spine1/LeftShoulder/LeftArm/A_LeftArm_Geom");
                    Transform transform2 = this.s105.transform.Find("ROOT/Hips/Spine/Spine1/LeftShoulder/LeftArm/LeftForeArm/A_LeftForeArm_Geom");
                    Transform transform3 = this.s105.transform.Find("ROOT/Hips/Spine/Spine1/LeftShoulder/LeftArm/LeftForeArm/LeftHand/pivot");
                    if (transform != null && transform2 != null && transform3 != null)
                    {
                        transform.gameObject.SetActive(true);
                        transform2.gameObject.SetActive(true);
                        transform3.gameObject.SetActive(true);
                        Debug.Log("S-105 Has Recovered His Left Arm!");
                        return;
                    }
                    Debug.LogError("Required Components Were Not Found!");
                    return;
                }
                else
                {
                    Debug.LogError("S-105 GameObject Not Found!");
                }
            }
        }

        public AddLeftArm()
        {
        }

        private GameObject s105;

    }
}
