using System.Collections;
using System.Collections.Generic;
using Loggers;
using UnityEngine;

public class ReturnToSpawnStatus
{
  private readonly DebugLogger _logger;

  public ReturnToSpawnStatus(DebugLogger logger)
  {
    _logger = logger;
  }

  public bool IsReturn { get; set; }
}