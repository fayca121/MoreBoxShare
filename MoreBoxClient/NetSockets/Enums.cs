using System;

namespace NetSockets
{
    /// <summary>
    /// Stop reasons.
    /// </summary>
    public enum NetStoppedReason { Manually, Remote, Exception };

    /// <summary>
    /// Rejection reasons.
    /// </summary>
    public enum NetRejectedReason { Full, Other };
}
