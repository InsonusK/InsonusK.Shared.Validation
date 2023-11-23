# Shared.Validation
Shared library of validation attributes

# Links
- [Nuget](https://www.nuget.org/packages/InsonusK.Shared.Validation)

# Using
## IsAttribute
```C#
using InsonusK.Shared.Validation;

public class TestClass{

  [Is(CompareType.GE, 10)]
  public int date;
}
```

## UTCKind
```C#
using InsonusK.Shared.Validation;

public class TestClass{

  [UTCKind]
  public DateTime date;
}
```
