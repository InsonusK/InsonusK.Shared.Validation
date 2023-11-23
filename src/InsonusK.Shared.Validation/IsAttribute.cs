using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;

namespace InsonusK.Shared.Validation;

/// <summary>
/// Validate field is compare to
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
public class IsAttribute<T> : ValidationAttribute where T : IComparable
{
  private readonly CompareType compareType;
  private readonly T compareValue;


  public IsAttribute(CompareType compareType, [NotNull] T compareValue)
  {
    Guard.Against.Null(compareValue);
    this.compareType = compareType;
    this.compareValue = compareValue;
  }

  public override bool RequiresValidationContext => false;
  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    var comparable = value is IComparable compValue ? compValue : throw new ArgumentException("Value type must be Comparable");
    var answer = comparable.CompareTo(this.compareValue);
    switch (this.compareType)
    {
      case CompareType.GE:
        if (answer >= 0) return ValidationResult.Success;
        break;
      case CompareType.GT:
        if (answer > 0) return ValidationResult.Success;
        break;
      case CompareType.LE:
        if (answer <= 0) return ValidationResult.Success;
        break;
      case CompareType.LT:
        if (answer < 0) return ValidationResult.Success;
        break;
      case CompareType.EQ:
        if (answer == 0) return ValidationResult.Success;
        break;
      case CompareType.NE:
        if (answer != 0) return ValidationResult.Success;
        break;
    }
    return new ValidationResult($"Value is not {Enum.GetName(this.compareType)} {this.compareValue}", new string[] { validationContext?.MemberName! });
  }
}
