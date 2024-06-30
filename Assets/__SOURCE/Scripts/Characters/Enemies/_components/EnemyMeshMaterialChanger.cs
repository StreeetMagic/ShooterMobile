using System;
using System.Collections.Generic;
using DG.Tweening;
using Infrastructure.ArtConfigServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMeshMaterialChanger : IInitializable, IDisposable
  {
    private readonly IHealth _health;
    private readonly List<Material> _originalMaterials = new();
    private readonly Material _newMaterial;
    private readonly Material _transitionMaterial;
    private readonly float _durationFirstMaterial;
    private readonly float _transitionDuration;
    private readonly float _durationSecondMaterial;

    private List<SkinnedMeshRenderer> _skinnedMeshRenderers;
    private Tween _tween;

    public EnemyMeshMaterialChanger(IHealth health, ArtConfigProvider artConfigProvider)
    {
      _health = health;

      _newMaterial = artConfigProvider.EnemyCommonVisualsConfig.NewMaterial;
      _transitionMaterial = artConfigProvider.EnemyCommonVisualsConfig.TransitionMaterial;
      _durationFirstMaterial = artConfigProvider.EnemyCommonVisualsConfig.DurationFirstMaterial;
      _transitionDuration = artConfigProvider.EnemyCommonVisualsConfig.TransitionDuration;
      _durationSecondMaterial = artConfigProvider.EnemyCommonVisualsConfig.DurationSecondMaterial;
    }

    public EnemyMeshModel EnemyMeshModel { get; set; }

    public void Initialize()
    {
      _health.Damaged += OnHealthChanged;

      if (EnemyMeshModel == null)
        throw new ArgumentNullException(nameof(EnemyMeshModel));

      _skinnedMeshRenderers = EnemyMeshModel.Meshes;

      foreach (SkinnedMeshRenderer renderer in _skinnedMeshRenderers)
      {
        if (renderer != null)
          _originalMaterials.Add(renderer.material);
        else
          Debug.LogError("One of the SkinnedMeshRenderers is not set.");
      }
    }

    public void Dispose()
    {
      _health.Damaged -= OnHealthChanged;
    }

    private void OnHealthChanged(float obj)
    {
      if (EnemyMeshModel != null)
      {
        ChangeMaterial();
      }
    }

    private void ChangeMaterial()
    {
      if (_newMaterial == null || _transitionMaterial == null || _skinnedMeshRenderers.Count != _originalMaterials.Count)
        Debug.LogError("SkinnedMeshRenderers, new material, or transition material is not set, or original materials list count does not match renderers list count.");

      foreach (SkinnedMeshRenderer renderer in _skinnedMeshRenderers)
        renderer.material = _newMaterial;
      
      if (_tween != null && _tween.active)
        _tween.Kill();

      _tween = DOVirtual.DelayedCall(_durationFirstMaterial, () =>
      {
        foreach (SkinnedMeshRenderer renderer in _skinnedMeshRenderers)
        {
          Material originalMaterial = _originalMaterials[_skinnedMeshRenderers.IndexOf(renderer)];
          renderer.material.DOColor(_transitionMaterial.color, _transitionDuration).OnComplete(() =>
          {
            renderer.material = _transitionMaterial;

            DOVirtual.DelayedCall(_durationSecondMaterial, () => { renderer.material.DOColor(originalMaterial.color, _transitionDuration).OnComplete(() => { renderer.material = originalMaterial; }); });
          });
        }
      });
    }
  }
}

