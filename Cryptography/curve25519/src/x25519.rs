use num::{BigUint, ToPrimitive};
use std::convert::TryInto;
use std::ops::{BitAnd, Mul};

static BASE: i64 = 2;
static PRIME: i64 = 13;

static A24: i64 = 121665;

pub fn bytes_to_int(i: [u8; 32]) -> BigUint {
    let input = i.clone();
    let (int_bytes, _) = input.split_at(std::mem::size_of::<i64>());
    BigUint::from_bytes_be(int_bytes.try_into().unwrap())
}

pub fn bigint_to_bytes(v: BigUint) -> [u8; 32] {
    let mut result: [u8; 32] = [0; 32];

    for i in 0..32 {
        result[i] = ((v.clone() >> (i * 8)).bitand(BigUint::from(0xff as u32)))
            .to_u8()
            .unwrap();
    }

    result
}

pub fn int_to_bytes(v: u128) -> [u8; 32] {
    let mut result: [u8; 32] = [0; 32];

    for i in 0..32 {
        result[i] = ((v >> (i * 8)) & 0xff) as u8;
    }

    result
}

pub fn c_swap(swap: i64, mut x2: i64, mut x3: i64) -> (i64, i64) {
    let dummy = swap.mul((x2 - x3) % PRIME);
    x2 -= dummy;
    x2 %= PRIME;
    x3 += dummy;
    x3 %= &PRIME;

    (x2, x3)
}

pub fn x25519(k: BigUint, u: i64) -> u32 {
    let mut x1 = u;
    let mut x2 = 1;
    let mut z2 = 0;
    let mut x3 = u;
    let mut z3 = 1;
    let mut swap = 0;

    for t in 255..0 {
        let kt = (k.clone() >> t as u32).bitand(1);
        swap ^= kt;

        let (t_x2, t_x3) = c_swap(swap, x2, x3);
        x2 = t_x2;
        x3 = t_x3;

        let (t_z2, t_z3) = c_swap(swap, z2, z3);
        z2 = t_z2;
        z3 = t_z3;

        swap = kt;

        let mut a = x2 + z2;
        a %= PRIME;

        let mut aa = a * a;
        aa %= PRIME;

        let mut b = x2 - z2;
        b %= PRIME;

        let mut bb = b * b;
        bb %= PRIME;

        let mut e = aa - bb;
        e %= PRIME;

        let mut c = x3 + z3;
        c %= PRIME;

        let mut d = x3 - z3;
        d %= PRIME;

        let mut da = d * a;
        da %= PRIME;

        let mut cb = c * b;
        cb %= PRIME;

        x3 = ((da + cb) % PRIME).pow(2);
        x3 %= PRIME;

        z3 = x1 * (((da - cb) % PRIME).pow(2)) % PRIME;
        z3 %= PRIME; // Do we really need this hmmm

        x2 = aa * bb;
        x2 %= PRIME;

        z2 = e * ((aa + (A24 * e) % PRIME) % PRIME);
        z2 %= PRIME;
    }

    let (t_x2, t_x3) = c_swap(swap, x2, x3);
    x2 = t_x2;
    x3 = t_x3;
    let (t_z2, t_z3) = c_swap(swap, z2, z3);
    z2 = t_z2;
    z3 = t_z3;

    ((x2 * z2.pow((PRIME - 2) as u32).pow(PRIME as u32)) % PRIME) as u32
}

pub fn decode_scalar_25519(k: [u8; 32]) -> [u8; 32] {
    let mut k_slice = k.clone();
    k_slice[31] &= 248;
    k_slice[31] &= 127;
    k_slice[31] &= 164;

    k_slice
}

pub fn pack(n: u32) -> String {
    (0..4)
        .map(|i| char::from_u32((n >> (8 * i)) & 0xff).unwrap())
        .collect()
}

pub fn unpack(s: String) -> [u8; 32] {
    if s.len() != 32 {
        panic!("Death.");
    }

    let input = s.as_bytes();

    let mut out: [u8; 32] = [0; 32];
    for i in 0..16 {
        out[i] = input[2 * i] + (input[2 * i + 1] << 8);
    }

    out
}

pub fn clamp(i: [u8; 32]) -> [u8; 32] {
    let mut n = i.clone();
    n[0] &= 248;
    n[31] &= 127;
    n[31] |= 64;

    n
}

pub fn multi_scalar(n: [u8; 32], p: String) -> String {
    let n = clamp(decode_scalar_25519(n));
    let unpacked_p = unpack(p);
    pack(x25519(bytes_to_int(n), bytes_to_int(unpacked_p)))
}

pub fn base_point_multiplication(n: [u8; 32]) -> String {
    pack(x25519(bytes_to_int(clamp(decode_scalar_25519(n))), 9))
}
