# Klinkby.Toolkitt

[![NuGet](https://img.shields.io/nuget/v/Klinkby.Toolkitt.svg)](https://www.nuget.org/packages/Klinkby.Toolkitt/)
[![Workflow](https://github.com/klinkby/toolkitt/actions/workflows/dotnet.yml/badge.svg)](https://github.com/klinkby/toolkitt/actions/workflows/dotnet.yml)
[![CodeQL](https://github.com/klinkby/toolkitt/actions/workflows/github-code-scanning/codeql/badge.svg)](https://github.com/klinkby/toolkitt/actions/workflows/github-code-scanning/codeql)
[![License](https://img.shields.io/github/license/klinkby/toolkitt.svg)](LICENSE)

## Summary

Just an evolving collection of AOT-friendly general purpose coding productivity 
tools. >95% test coverage, >80% [Stryker](https://stryker-mutator.io/) mutation score.


## Contents

- Explicit parameter validation guard extension methods
- Thread-safe event raiser extension methods
- Apply, Curry, Uncurry extension methods for `Func<T>`
- Apply for extension methods `Action<T>`
- Monads `Identity<T>` and `Either<T>` (`Left<T>` / `Right<T>`)
- Base64 URL encoding/decoding
- DateTime extension methods e.g. safely formatting UTC date 
- Adapter for passing Microsoft.Extensions.ILogger output to XUnit console
- Create Tuple from IEnumerable

## Package

Nuget package: [Klinkby.Toolkitt](https://www.nuget.org/packages/Klinkby.Toolkitt/) for netstandard2.1


## License

MIT licensed. See [LICENSE](https://github.com/klinkby/toolkitt/blob/main/LICENSE) for details.


## Dependencies

- netcore3.0 or later
