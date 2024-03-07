// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using System.Diagnostics.CodeAnalysis;
using SixLabors.ImageSharp.ColorProfiles;

namespace SixLabors.ImageSharp.Tests.ColorProfiles;

/// <summary>
/// Allows the approximate comparison of color profile component values.
/// </summary>
internal readonly struct ApproximateColorProfileComparer :
    IEqualityComparer<CieLab>,
    IEqualityComparer<CieXyz>,
    IEqualityComparer<Lms>
{
    private readonly float epsilon;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApproximateColorProfileComparer"/> struct.
    /// </summary>
    /// <param name="epsilon">The comparison error difference epsilon to use.</param>
    public ApproximateColorProfileComparer(float epsilon = 1f) => this.epsilon = epsilon;

    public bool Equals(CieLab x, CieLab y) => this.Equals(x.L, y.L) && this.Equals(x.A, y.A) && this.Equals(x.B, y.B);

    public bool Equals(CieXyz x, CieXyz y) => this.Equals(x.X, y.X) && this.Equals(x.Y, y.Y) && this.Equals(x.Z, y.Z);

    public bool Equals(Lms x, Lms y) => this.Equals(x.L, y.L) && this.Equals(x.M, y.M) && this.Equals(x.S, y.S);

    public int GetHashCode([DisallowNull] CieLab obj) => obj.GetHashCode();

    public int GetHashCode([DisallowNull] CieXyz obj) => obj.GetHashCode();

    public int GetHashCode([DisallowNull] Lms obj) => obj.GetHashCode();

    private bool Equals(float x, float y)
    {
        float d = x - y;
        return d >= -this.epsilon && d <= this.epsilon;
    }
}
