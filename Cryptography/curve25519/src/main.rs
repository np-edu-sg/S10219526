// Curve25519 uses y^2 = x^3 + 486662x^2 + x
// with prime number 2^255-19

use rand::random;

fn main() {
    let a_private: u32 = random();
    let b_private: u32 = random();
}

fn clamp(mut n: u32) {
    // n &= ~7
    n = n & -8;
    n = n & (128 << 8 * 32);
}

fn base_point_multiplication(mut n: u32) {
    n = clamp(decode_scalar25519(n));
    return pack(x25519(n, 9))
}
