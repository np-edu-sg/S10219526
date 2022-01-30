package main

import (
	"crypto/cipher"
	"crypto/rand"
	"fmt"
	"io"
	"math/big"
	"time"

	"golang.org/x/crypto/curve25519"
	"golang.org/x/crypto/twofish"

	"github.com/binance-chain/tss-lib/crypto/paillier"
	"github.com/cloudflare/redoctober/padding"
)

const (
	paillierKeyLength = 1024
)

func waitEnter() {
	fmt.Println("Press ENTER to continue...")
	_, _ = fmt.Scanln()
}

func gen32ByteRandom() ([]byte, error) {
	random := make([]byte, 32)
	_, err := rand.Read(random)
	if err != nil {
		return nil, err
	}

	return random, err
}

// genCurve25519Keys returns a private key, public key, and error
func genCurve25519Keys() ([]byte, []byte, error) {
	// Generate randoms
	private, err := gen32ByteRandom()
	if err != nil {
		return nil, nil, err
	}

	pub, err := curve25519.X25519(private, curve25519.Basepoint)

	return private, pub, err
}

// 1. Generate Alice and Bobs Paillier pub and priv key
// 2. Generate Alice and Bobs curve25519 pub and priv key

// 3. Alice and Bob exchanges curve25519 pub key with Paillier encryption. Assume each others Paillier public keys are known and secure
// 4. Alice and Bob generate shared curve25519 secret
// 5. Alice encrypts some data through Twofish with curve25519 secret
// 6. Bob decrypts
func main() {
	fmt.Println("CTG Assignment Demonstration")
	fmt.Println("NOTE: All values are displayed in hex")
	fmt.Println()

	alicePaillierPrivate, alicePaillierPub, err := paillier.GenerateKeyPair(paillierKeyLength, 10*time.Minute)
	if err != nil {
		panic(err)
	}

	fmt.Printf("Alice Paillier Keys:\nPublic: %x\nPrivate: %x\n\n", alicePaillierPub.N, alicePaillierPrivate.LambdaN)

	bobPaillierPrivate, bobPaillierPub, err := paillier.GenerateKeyPair(paillierKeyLength, 10*time.Minute)
	if err != nil {
		panic(err)
	}

	fmt.Printf("Bob Paillier Keys:\nPublic: %x\nPrivate: %x\n\n", bobPaillierPub.N, bobPaillierPrivate.LambdaN)

	aliceCurvePrivate, aliceCurvePub, err := genCurve25519Keys()
	if err != nil {
		panic(err)
	}

	waitEnter()

	fmt.Printf("Alice Curve25519 Keys:\nPublic: %x\nPrivate: %x\n\n", aliceCurvePub, aliceCurvePrivate)

	bobCurvePrivate, bobCurvePub, err := genCurve25519Keys()
	if err != nil {
		panic(err)
	}

	fmt.Printf("Bob Curve25519 Keys:\nPublic: %x\nPrivate: %x\n\n", bobCurvePub, bobCurvePrivate)

	e := new(big.Int)
	e.SetBytes(aliceCurvePub)

	aliceCurvePubEnc, err := bobPaillierPub.Encrypt(e)
	if err != nil {
		panic(err)
	}

	waitEnter()

	fmt.Printf("Alice sends her Curve25519 Public key encrypted with Bob Paillier public key: %x\n\n", aliceCurvePubEnc)

	aliceCurvePubDec, err := bobPaillierPrivate.Decrypt(aliceCurvePubEnc)

	waitEnter()

	fmt.Printf("Bob decrypts Alice Curve25519 Public key with his Paillier private key: %x\n\n", aliceCurvePubDec)

	e = new(big.Int)
	e.SetBytes(bobCurvePub)

	bobCurvePubEnc, err := alicePaillierPub.Encrypt(e)
	if err != nil {
		panic(err)
	}

	waitEnter()

	fmt.Printf("Bob sends his Curve25519 Public key encrypted with Alice Paillier public key: %x\n\n", bobCurvePubEnc)

	bobCurvePubDec, err := alicePaillierPrivate.Decrypt(bobCurvePubEnc)

	waitEnter()

	fmt.Printf("Alice decrypts Bob Curve25519 Public key with her Paillier private key: %x\n\n", bobCurvePubDec)

	aliceAgreed, err := curve25519.X25519(aliceCurvePrivate, bobCurvePubDec.Bytes())
	if err != nil {
		panic(err)
	}

	waitEnter()

	fmt.Printf("Alice arrives at secret: %x\n\n", aliceAgreed)

	bobAgreed, err := curve25519.X25519(bobCurvePrivate, aliceCurvePubDec.Bytes())
	if err != nil {
		panic(err)
	}

	waitEnter()

	fmt.Printf("Bob arrives at secret: %x\n\n", bobAgreed)

	fmt.Println("Alice now encrypts some data to send to Bob")

	tfCipher, err := twofish.NewCipher(aliceAgreed)
	if err != nil {
		panic(err)
	}

	var input string
	for {
		fmt.Print("Enter some data to encrypt: ")
		_, err = fmt.Scanln(&input)
		if err == nil {
			break
		}
		fmt.Println("Invalid input")
	}

	paddedInput := padding.AddPadding([]byte(input))

	ciphertext := make([]byte, len(paddedInput))
	plaintext := make([]byte, len(paddedInput))

	iv := make([]byte, twofish.BlockSize)
	if _, err := io.ReadFull(rand.Reader, iv); err != nil {
		panic(err)
	}

	enc := cipher.NewCBCEncrypter(tfCipher, iv)
	dec := cipher.NewCBCDecrypter(tfCipher, iv)

	enc.CryptBlocks(ciphertext, paddedInput)

	fmt.Printf("\nAlice encrypts data with shared secret:\nCiphertext: %x\n\n", ciphertext)

	dec.CryptBlocks(plaintext, ciphertext)
	pt, err := padding.RemovePadding(plaintext)
	if err != nil {
		panic(err)
	}

	waitEnter()
	fmt.Printf("Bob decrypts data with shared secret:\nPlaintext: %s\n", pt)

	waitEnter()
}
