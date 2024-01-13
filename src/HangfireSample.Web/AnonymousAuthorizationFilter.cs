// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace HangfireSample.Web;

public sealed class AnonymousAuthorizationFilter : IDashboardAuthorizationFilter
{
  public bool Authorize([NotNull] DashboardContext context) => true;
}
