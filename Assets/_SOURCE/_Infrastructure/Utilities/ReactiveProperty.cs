﻿using System;

namespace Infrastructure.Utilities
{
  [Serializable]
  public class ReactiveProperty<T>
  {
    private T _value;

    public ReactiveProperty()
    {
      Value = default(T);
    }

    public ReactiveProperty(T value)
    {
      Value = value;
    }

    public event Action<T> ValueChanged;

    public T Value
    {
      get => _value;
      set
      {
        _value = value;
        ValueChanged?.Invoke(_value);
      }
    }
  }
}