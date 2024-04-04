using System.Collections;
using System.Collections.Generic;
using Loggers;
using UnityEngine;

public class ReturnToSpawnStatus
{
  private readonly DebugLogger _logger;

  private bool _isReturn;

  public ReturnToSpawnStatus(DebugLogger logger)
  {
    _logger = logger;
  }

  public bool IsReturn
  {
    get => _isReturn;
    set
    {
      _logger.Log($"IsReturn: {value}");
      _isReturn = value;
    }
  }
}