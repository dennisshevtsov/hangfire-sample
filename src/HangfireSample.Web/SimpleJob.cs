// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace HangfireSample.Web;

public sealed class SimpleJob(ILogger<SimpleJob> logger)
{
  private readonly ILogger<SimpleJob> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

  public void Execute(string backgroundJobName) =>
    _logger.LogInformation("{JobName} has beed excuted at {Time}.", backgroundJobName, DateTime.UtcNow);
}
