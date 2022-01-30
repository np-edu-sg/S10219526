# Cryptography Demo

## Get Started

Common platform executables have been included:

| OS      | Arch  | Executable Name          |
|---------|-------|--------------------------|
| Windows | x64   | `main-windows-amd64.exe` |
| macOS   | x64   | `main-darwin-amd64`      |
| macos   | arm64 | `main-darwain-arm64`     |

If your platform is not included above, you need to build the binary.

### Build

This is a typical Go program using Go modules with only 1 file - `main.go`

#### Prerequisites

* Go v1.17

```shell
#!/usr/bin/env sh

go mod download
go build main.go
```