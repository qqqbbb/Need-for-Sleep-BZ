using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Need_for_Sleep_BZ
{
    internal class Util
    {
        public static bool IsGameLoadedAndRunning()
        {
            return Main.gameLoaded && Time.timeScale > 0;
        }

        public static bool IsPlayerInDropPod()
        {
            return Player.main.currentInterior is LifepodDrop;
        }

        public static float MapTo01range(int value, int min, int max)
        {
            float fl;
            int oldRange = max - min;

            if (oldRange == 0)
                fl = 0f;
            else
                fl = ((float)value - (float)min) / (float)oldRange;

            return fl;
        }


        public static IEnumerator Spawn(TechType techType, IOut<GameObject> result, Vector3 pos = default, Vector3 rot = default)
        {
            //AddDebug("Spawn " + techType);
            GameObject prefab;
            TaskResult<GameObject> result_ = new TaskResult<GameObject>();
            yield return CraftData.GetPrefabForTechTypeAsync(techType, false, result_);
            prefab = result_.Get();
            GameObject go = prefab == null ? Utils.CreateGenericLoot(techType) : Utils.SpawnFromPrefab(prefab, null);
            if (go != null)
            {
                result.Set(go);
                if (pos == default)
                {
                    Transform camTr = MainCamera.camera.transform;
                    go.transform.position = camTr.position + camTr.forward * 3f;
                }
                else
                    go.transform.position = pos;

                if (rot == default)
                    go.transform.rotation = Quaternion.identity;
                else
                    go.transform.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);

                //AddDebug($"Spawn {techType} {pos} {rot}");
                //CrafterLogic.NotifyCraftEnd(go, techType);
            }
        }

        public static bool IsPlayerInTruck()
        {
            return Player.main.currentInterior is SeaTruckSegment;
        }



    }
}
