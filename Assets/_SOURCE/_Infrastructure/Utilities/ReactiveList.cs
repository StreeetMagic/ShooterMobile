using System;
using System.Collections.Generic;

namespace Utilities
{
  public class ReactiveList<T>
  {
    private List<T> _list;

    public ReactiveList()
    {
      _list = new List<T>();
    }

    public ReactiveList(List<T> list)
    {
      _list = list;
    }

    public event Action<List<T>> Changed;

    public List<T> Value
    {
      get => _list;
      set
      {
        _list = value;
        Changed?.Invoke(_list);
      }
    }

    public void Add(T value)
    {
      _list.Add(value);
      Changed?.Invoke(_list);
    }

    public void Remove(T value)
    {
      _list.Remove(value);
      Changed?.Invoke(_list);
    }

    public void Clear()
    {
      _list.Clear();
      Changed?.Invoke(_list);
    }
  }
}