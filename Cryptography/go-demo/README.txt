Cryptography Demo

    1.  Get Started

        Common platform executables have been included:

        | OS      | Arch  | Executable Name          |
        |---------|-------|--------------------------|
        | Windows | x64   | `main-windows-amd64.exe` |
        | macOS   | x64   | `main-darwin-amd64`      |
        | macos   | arm64 | `main-darwain-arm64`     |

        Simply run the executable, and you will be presented with a terminal interface.
        Else you may also choose to run them from your prefered terminal application.
        NOTE: On macOS, you may have to open the executables from the terminal.

        If your platform is not included above, you need to build the binary, follow steps below.

    2.  Build

        This is a typical Go program using Go modules with only 1 file - `main.go`

        2.1.    Prerequisites

                - Go v1.17 (install from https://go.dev)

        ```shell
        #!/usr/bin/env sh

        go mod download
        go build main.go
        ```