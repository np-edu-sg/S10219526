// Curve25519 uses y^2 = x^3 + 486662x^2 + x
// with prime number 2^255-19

use num::{BigInt, BigUint};
use rand::{thread_rng, Rng};

use crate::x25519::{bigint_to_bytes, int_to_bytes};

mod x25519;

fn main() {
    println!("{:?}", gen_bob_public());
}

fn gen_bob_public() -> String {
    let rand = rand::thread_rng().gen::<[u8; 32]>();
    x25519::base_point_multiplication(rand)
}
