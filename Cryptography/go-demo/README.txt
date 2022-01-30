Cryptography Demo

    1.  Get Started

        Common platform executables have been included:

        | OS      | Arch  | Executable Name          |
        |---------|-------|--------------------------|
        | Windows | x64   | `main-windows-amd64.exe` |
        | macOS   | x64   | `main-darwin-amd64`      |
        | macos   | arm64 | `main-darwin-arm64`      |

        If your platform is not included above, you need to build the executable yourself.
        Simply run the executable, and you will be presented with a terminal interface.
        Else you may also choose to run them from your preferred terminal application.
        NOTE: On macOS, you may have to open the executables from the terminal.

    2.  Build

        This is a typical Go program using Go modules with only 1 file - `main.go`

        2.1.    Prerequisites

                - Go v1.17 (install from https://go.dev)

        ```shell
        #!/usr/bin/env sh

        go mod download
        go build main.go
        ```

    3.  Output

        The program demonstrates Alice and Bob establishing a secure channel to transfer files using:

        * Asymmetric encryption: Paillier
        * Symmetric encryption: Twofish
        * Key exchange: Curve25519

        The outputs of each of the steps is printed in the terminal.

        To proceed to the next step, press ENTER.

        At the end of the entire process, pressing ENTER will exit the program.