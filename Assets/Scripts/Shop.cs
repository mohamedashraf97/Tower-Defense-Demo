using UnityEngine;

public class Shop : MonoBehaviour {

 public TurrentBluePrint standardTurrent;
 public TurrentBluePrint missileLauncher ;

 BuildManager  buildManager ;

 void Start()
 {
      buildManager = BuildManager.instance ;
 }
   public void SelectStandardTurrent(){

	   buildManager.SelectTurrentToBuild(standardTurrent);
   }

    public void SelectMissleTurrent(){

	   buildManager.SelectTurrentToBuild(missileLauncher);
   }
}
