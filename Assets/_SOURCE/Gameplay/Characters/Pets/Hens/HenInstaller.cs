using UnityEngine;
using Zenject.Source.Install;

public class HenInstaller : MonoInstaller
{
  public override void InstallBindings()
  {
    Container.Bind<HenMover>().FromInstance(GetComponent<HenMover>());
    Container.Bind<HenPlayerFollower>().FromInstance(GetComponent<HenPlayerFollower>());
    Container.Bind<HenRotator>().FromInstance(GetComponent<HenRotator>());
    Container.Bind<CharacterController>().FromInstance(GetComponent<CharacterController>());
  }
}