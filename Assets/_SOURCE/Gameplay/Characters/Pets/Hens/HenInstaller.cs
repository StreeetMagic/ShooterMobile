using Gameplay.Characters.Pets.Hens;
using Gameplay.Characters.Pets.Hens._components;
using UnityEngine;
using Zenject.Source.Install;

public class HenInstaller : MonoInstaller
{
  public override void InstallBindings()
  {
    Container.Bind<Hen>().FromInstance(GetComponent<Hen>());
    Container.Bind<HenMover>().FromInstance(GetComponent<HenMover>());
    Container.Bind<HenToPlayerFollower>().FromInstance(GetComponent<HenToPlayerFollower>());
    Container.Bind<HenRotator>().FromInstance(GetComponent<HenRotator>());
    Container.Bind<CharacterController>().FromInstance(GetComponent<CharacterController>());
    Container.Bind<HenVisualEffector>().FromInstance(GetComponent<HenVisualEffector>());
    Container.Bind<HenBehaviourController>().FromInstance(GetComponent<HenBehaviourController>());
    Container.Bind<HenToTargetFollower>().FromInstance(GetComponent<HenToTargetFollower>());
    Container.Bind<HenDamageDealer>().FromInstance(GetComponent<HenDamageDealer>());
  }
}