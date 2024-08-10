[![.NET](https://github.com/aimenux/ParameterisedTestsDemo/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/aimenux/ParameterisedTestsDemo/actions/workflows/ci.yml)

# ParameterisedTestsDemo
```
Comparing the use of parameterized tests across various unit tests frameworks
```

In this demo, i m comparing the use of parameterized tests across various unit tests frameworks.

| MSTest | NUnit | XUnit |
|:-:|:-:|:-:|
| DataTestMethod  | Test | Theory |
| DataRow  | TestCase | InlineData |
| DynamicData  | TestCaseData, TestCaseSource | MemberData, ClassData, TheoryData |

**`Tools`** : net 8.0, mstest, nunit, xunit