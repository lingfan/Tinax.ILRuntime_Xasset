using Nekonya.UI;
using TinaX;
//using TinaX.VFSKit;
using TinaX.UIKit;
using XAsset;
using libx;
using UniRx;
using UnityEngine;


namespace Nekonya
{
    public class MeowStartup
    {
        public static void Start()
        {
            Debug.Log("Meow~~~");
            //open ui
            var core = XCore.GetMainInstance();
            var uikit = core.Services.Get<IUIKit>();
            uikit.OpenUIAsync("mainScreen", new MainScreen(), (entity, err) =>
            {
                if (err != null)
                {
                    Debug.LogError("Open mainScreen failed:" + err.Message);
                }
            });

            //load scene
            //var vfs = core.GetService<IVFS>();
            //vfs.LoadSceneAsync("Assets/App/Scenes/App.Main.unity", (scene, err) =>
            //{
            //    scene.OpenScene();
            //});
            var scene_req = Assets.LoadSceneAsync("Assets/App/Scenes/App.Main.unity", false);
            scene_req.ToObservable()
                .ObserveOnMainThread()
                .SubscribeOnMainThread()
                .Subscribe(_ =>
                {
                    Debug.Log("Load Scene Success");
                });
        }
    }
}
