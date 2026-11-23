# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

Humbatt.UI.Toolkit — UI controls, converters, behaviours and helpers for WPF, WinUI and MAUI. Six NuGet packages:

- `Humbatt.UI.Toolkit.Core` (`Humbatt.UI.Toolkit.Core/`) — shared models and helpers, `netstandard2.0`.
- `Humbatt.UI.Toolkit.WPF`, `.WPF.Metro` (MahApps) and `.WPF.Mvvm` (DSoft.System.Mvvm) — WPF, `net10.0-windows`, `net10.0-windows10.0.18362`, `net11.0-windows`, `net11.0-windows10.0.18362`.
- `Humbatt.UI.Toolkit.WinUI` — WinUI 3 (Windows App SDK), `net10.0-windows10.0.19041.0` and `net11.0-windows10.0.19041.0`. Some sources are shared with WPF (`*.winui.wpf.cs`).
- `Humbatt.UI.Toolkit.Mobile` — MAUI converters, `net10.0` and `net11.0` for android, ios, maccatalyst and (on Windows) windows. `Microsoft.Maui.Controls` is 10.0.20 for net10 and 11.0.10 for net11.

Samples: `HumbattUIKitSample` (WPF) and `WinUISample` (WinUI). `WpfSample` is an old sample that is not in the solution and does not reference the toolkit, so it does not build; leave it alone. There are no automated tests.

## Build

```bash
dotnet workload restore Humbatt.UI.Toolkit.slnx     # MAUI workloads
dotnet restore Humbatt.UI.Toolkit.slnx
dotnet build Humbatt.UI.Toolkit.slnx -c Release
```

- Build with the .NET 10 and .NET 11 SDKs (`global.json` rolls forward to the latest major). The full solution needs Windows (WPF, WinUI) and the MAUI workloads. On Linux, build individual projects and add `-p:EnableWindowsTargeting=true` for WPF, for example `dotnet build Humbatt.UI.Toolkit.Core/Humbatt.UI.Toolkit.Core.csproj -c Release`. The WinUI and Mobile projects cannot be built there.
- `net11.0-android` needs a minimum Android API of 24 (set per target framework in the Mobile project).
- `GeneratePackageOnBuild=true` (`Directory.Build.props`), so every build produces `.nupkg` files with `README.md` and `HumbattIcon.png`. Release builds add SourceLink and an embedded PDB.
- Assemblies are strong-name signed with each project's `humbatt.snk`; do not remove those files. Versions are not set in the csproj files: the release workflow injects them.

## Branching

- `development` is the working branch: branch from it and open pull requests into it. Never commit or open a pull request directly against `main`.
- `main` is the release branch. Every push to `main` runs `release.yml`, which publishes the packages to nuget.org and creates a GitHub release, so only merge `development` into `main` when a release is intended, and only when asked to release.

## CI

GitHub Actions (`.github/workflows/`) on `windows-latest`, with the workloads restored by `dotnet workload restore`:

- `ci.yml` builds Release for pull requests into `main` and `development`; it publishes nothing.
- `release.yml` runs on every push to `main` (changes only to Markdown or workflow files are skipped; run it by hand to test a workflow change). It builds Release as `11.0.<yyMM>.<run number>` plus `RELEASE_SUFFIX` (empty for a stable version), pushes the packages to nuget.org with Trusted Publishing (OIDC, `NUGET_USER` secret, `nuget` environment), then tags the commit `v<version>` and creates a GitHub release with the packages attached.
